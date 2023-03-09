package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Preferences;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.math.Vector3;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.Contact;
import com.badlogic.gdx.physics.box2d.ContactImpulse;
import com.badlogic.gdx.physics.box2d.ContactListener;
import com.badlogic.gdx.physics.box2d.Manifold;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.Actor;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.actions.Actions;
import com.badlogic.gdx.scenes.scene2d.ui.ImageButton;
import com.badlogic.gdx.scenes.scene2d.ui.Label;
import com.badlogic.gdx.scenes.scene2d.utils.ChangeListener;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.Align;
import com.badlogic.gdx.utils.I18NBundle;
import com.badlogic.gdx.utils.viewport.StretchViewport;
import com.mygdx.game.entities.BatEntity;
import com.mygdx.game.entities.CardEntity;
import com.mygdx.game.entities.FloorEntity;
import com.mygdx.game.entities.PlayerEntity;
import com.mygdx.game.entities.RatEntity;
import com.mygdx.game.entities.SnakeEntity;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class GameScreen extends BaseScreen {

    private Stage stage;
    private World world;

    private PlayerEntity player;

    private List<FloorEntity> floorList = new ArrayList<FloorEntity>();

    private ArrayList<RatEntity> ratList = new ArrayList<RatEntity>();

    private ArrayList<BatEntity> batList = new ArrayList<BatEntity>();

    private ArrayList<SnakeEntity> snakeList = new ArrayList<SnakeEntity>();

    private List<CardEntity> cardList = new ArrayList<CardEntity>();

    private Music gameMusic, dieMusic;

    private Sound jump, ratSound, screamSound;

    private Texture playerTexture, floorTexture, overfloorTexture, ratTexture, jumpTexture, shootTexture, snakeTexture, batTexture, cardTexture;

    private Vector3 camPos;

    private Label score;

    private Label.LabelStyle labelStyle;

    private BitmapFont font;

    private I18NBundle i18NBundle;

    private ImageButton jumpImage, shootImage;

    private Date date;

    private SimpleDateFormat smf;

    private String scoreDate;

    private Float accum = 0f, delay, magoPos = 0f, floorPos = 0f, acelerometerZ;

    private boolean screamOn = true;

    private int scorePoints = 0, batPos = 0, ratPos = 0, snakePos = 0;

    private Preferences preferences;

    private OptionsScreen optionsScreen;

    public GameScreen(final MyMagoGame game) {
        super(game);
        stage = new Stage(new StretchViewport(840, 560));
        world = new World(new Vector2(0, -10), true);

        camPos = new Vector3(stage.getCamera().position);

        preferences = Gdx.app.getPreferences("MagoVago");

        optionsScreen = new OptionsScreen(game);

        acelerometerZ = Gdx.input.getAccelerometerZ();

        playerTexture = game.getManager().get("MagoStand.png");
        cardTexture = game.getManager().get("Blackcard.png");
        floorTexture = game.getManager().get("Floor.png");
        overfloorTexture = game.getManager().get("Overfloor.png");
        ratTexture = game.getManager().get("Rata.png");
        snakeTexture = game.getManager().get("Serpiente.png");
        batTexture = game.getManager().get("Murcielago.png");
        player = new PlayerEntity(world, playerTexture, new Vector2(1.5f, 1.5f));

        floorList.add(new FloorEntity(world, floorTexture, overfloorTexture, 0, 1, Constants.FLOOR_SIZE));

        labelStyle = new Label.LabelStyle();
        font = new BitmapFont(Gdx.files.internal("GameFont.fnt"));
        labelStyle.font = font;
        labelStyle.fontColor = Color.WHITE;

//        i18NBundle = game.getManager().get("strings/strings.xml");
        score = new Label("Score:", labelStyle);

        score.setSize(score.getWidth() + 80, score.getHeight() + 50);
        score.setPosition(500, Gdx.graphics.getHeight());
        score.setAlignment(Align.right);


        gameMusic = game.getManager().get("GameSong.ogg");
        dieMusic = game.getManager().get("GameOver.ogg");
        jump = game.getManager().get("Jump.ogg");
        ratSound = game.getManager().get("Rat.ogg");
        screamSound = game.getManager().get("Scream.ogg");

        if (Locale.getDefault().equals(new Locale("es", "ES"))) {
            jumpTexture = new Texture(Gdx.files.internal("SaltoButton.png"));
            shootTexture = new Texture(Gdx.files.internal("DisparoButton.png"));
        } else {
            jumpTexture = new Texture(Gdx.files.internal("JumpButton.png"));
            shootTexture = new Texture(Gdx.files.internal("ShootButton.png"));
        }

        jumpImage = new ImageButton(new TextureRegionDrawable(new TextureRegion(jumpTexture)));
        shootImage = new ImageButton(new TextureRegionDrawable(new TextureRegion(shootTexture)));

        jumpImage.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                if (!player.isJumping()) {
                    jump.play();
                    player.jump();
                }
            }
        });

        shootImage.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                System.out.println("CARTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
                CardEntity card = new CardEntity(world, cardTexture, player.getX(), player.getY());
                cardList.add(card);
                stage.addActor(card);
//                stage.addActor(new CardEntity(world, cardTexture, player.getX() / Constants.PIXELS_IN_METER + 1, player.getY() / Constants.PIXELS_IN_METER + 0.6f));

            }
        });


        world.setContactListener(new ContactListener() {

            private boolean areCollied(Contact contact, Object userA, Object userB) {
                return (contact.getFixtureA().getUserData().equals(userA) && contact.getFixtureB().getUserData().equals(userB)) ||
                        (contact.getFixtureA().getUserData().equals(userB) && contact.getFixtureB().getUserData().equals(userA));
            }

            @Override
            public void beginContact(Contact contact) {
                if (areCollied(contact, "player", "floor")) {
                    player.setJumping(false);
                    if (Gdx.input.isTouched()) {
                        player.setMustJump(true);
                    }
                }

                if (areCollied(contact, "player", "rat") || areCollied(contact, "player", "snake") || areCollied(contact, "player", "bat")) {
                    player.setAlive(false);
                    if (!optionsScreen.offVibration) {
                        Gdx.input.vibrate(1000);
                    }
                    gameMusic.stop();
                    dieMusic.play();
                    stage.addAction(Actions.sequence(Actions.delay(0.8f), Actions.run(new Runnable() {
                        @Override
                        public void run() {
                            game.setScreen(game.gameOverScreen);
                        }
                    })));
                }

                if (areCollied(contact, "player", "leftBox")) {
                    player.setAlive(false);
                    if (!optionsScreen.offVibration) {
                        Gdx.input.vibrate(1000);
                    }
                    stage.addAction(Actions.sequence(Actions.delay(1), Actions.run(new Runnable() {
                        @Override
                        public void run() {
                            game.setScreen(game.gameOverScreen);
                        }
                    })));
                }
            }

            @Override
            public void endContact(Contact contact) {

            }

            @Override
            public void preSolve(Contact contact, Manifold oldManifold) {
                //TODO FUNCION DE DISPARO
                if (areCollied(contact, "rat", "card")) {
                    Body body = null;
                    if (contact.getFixtureA().getBody().equals("rat")) {
                        body = contact.getFixtureA().getBody();
                        for (RatEntity r : ratList) {
                            if (r.getBody() == body) {
                                r.setDead(true);
                                System.out.println("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                            }

                        }
                    } else {
                        body = contact.getFixtureB().getBody();
                        for (RatEntity r : ratList) {
                            if (r.getBody() == body) {
                                r.setDead(true);
                                System.out.println("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
                            }
                        }

                    }
//                    body.applyLinearImpulse(body.getLinearVelocity().x, IMPULSE_JUMP / 1.9f, body.getPosition().x, body.getPosition().y, true);

                }
            }

            @Override
            public void postSolve(Contact contact, ContactImpulse impulse) {

            }
        });

    }

    @Override
    public void show() {
        Gdx.input.setInputProcessor(stage);

        stage.addActor(player);
        stage.addActor(score);

        stage.getCamera().position.set(camPos);
        stage.getCamera().update();

        for (FloorEntity floor : floorList) {
            stage.addActor(floor);
        }

        stage.addActor(jumpImage);
        stage.addActor(shootImage);

        if (!optionsScreen.offVolume) {
            gameMusic.play();
            gameMusic.setLooping(true);
        }
    }

    @Override
    public void hide() {
        Gdx.input.setInputProcessor(null);

        player.detach();
        for (FloorEntity floor : floorList) {
            floor.detach();
            floor.remove();
        }
        for (RatEntity rat : ratList) {
            rat.detach();
            rat.remove();
        }
        for (SnakeEntity snake : snakeList) {
            snake.detach();
            snake.remove();
        }
        for (BatEntity bat : batList) {
            bat.detach();
            bat.remove();
        }

        score.remove();
        jumpImage.remove();
        shootImage.remove();
        floorList.clear();

        saveScore();
        preferences.putString("score", scoreDate + " - " + scorePoints);
        preferences.flush();

        stage.getActors().clear();
        stage.clear();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor(0.2f, 0.2f, 0.2f, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        accum += delta;
        delay = 1f;

        loadBackground();

        stage.act();
        world.step(delta, 6, 2);

        if (player.isAlive() && player.getX() > 150) {
            stage.getCamera().translate(Constants.PLAYER_SPEED * delta * Constants.PIXELS_IN_METER, 0, 0);
        }

        score.setText("Score: " + scorePoints);
        score.setPosition(stage.getCamera().position.x + 200, score.getY());
        jumpImage.setPosition(stage.getCamera().position.x - 400, 0);
        shootImage.setPosition(stage.getCamera().position.x + 320, 0);

        if (!player.isJumping() && jumpImage.isPressed()) {
            jump.play();
            player.jump();
        }

        if (accum >= delay) {
            accum = 0f;
            randGame();
            scorePoints += 1;
            if(accum >= delay + 10) {
                screamOn
            }
        }

        if (acelerometerZ > Gdx.input.getAccelerometerZ() || acelerometerZ < Gdx.input.getAccelerometerZ()) {
            screamSound.play();
        }

        stage.draw();
    }

    @Override
    public void dispose() {
        gameMusic.dispose();
        jump.dispose();
        ratSound.dispose();
        playerTexture.dispose();
        floorTexture.dispose();
        overfloorTexture.dispose();
        ratTexture.dispose();
        snakeTexture.dispose();
        batTexture.dispose();
        jumpTexture.dispose();
        shootTexture.dispose();
        stage.dispose();
        world.dispose();
    }

    public String saveScore() {
        date = Calendar.getInstance().getTime();
        smf = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());

        scoreDate = smf.format(date);
        return scoreDate;
    }

    public void randGame() {
        magoPos = player.getX() / Constants.PIXELS_IN_METER;
        if (player.isAlive()) {

            //SPAWN DE SUELO INFINITO
            if (floorPos - magoPos < 20f) {
                stage.addActor(new FloorEntity(world, floorTexture, overfloorTexture, floorPos, 1, Constants.FLOOR_SIZE));
                shootImage.toFront();
                jumpImage.toFront();
                floorPos += 100f;
            }

            //SPAWN DE ELEVACIONES DE SUELO
            int floorRand = (int) (Math.random() * 101 + 0);
            if (floorRand > 80) {
                stage.addActor(new FloorEntity(world, floorTexture, overfloorTexture, player.getX() / Constants.PIXELS_IN_METER + 20, 2, 10));
                jumpImage.toFront();
                shootImage.toFront();
            }

            //SPAWN DE ENEMIGOS ALEATORIO
            int enemyRand = (int) (Math.random() * 100 + 0);
            System.out.println("ENEMY RAND:    " + enemyRand);
            if (enemyRand <= 33) {
                System.out.println("RAT SPAWNED");
                RatEntity rat = new RatEntity(world, ratTexture, player.getX() / Constants.PIXELS_IN_METER + 20, 3);
                ratList.add(rat);
                stage.addActor(rat);
                jumpImage.toFront();
                shootImage.toFront();
            } else if (enemyRand > 33 && enemyRand <= 66) {
                System.out.println("SNAKE SPAWNED");
                SnakeEntity snake = new SnakeEntity(world, snakeTexture, player.getX() / Constants.PIXELS_IN_METER + 20, 3);
                snakeList.add(snake);
                stage.addActor(snake);
                jumpImage.toFront();
                shootImage.toFront();
            } else {
                int randBatSpawn = (int) (Math.random() * 6 + 3);
                System.out.println("BAT SPAWNED");
                BatEntity bat = new BatEntity(world, batTexture, player.getX() / Constants.PIXELS_IN_METER + 20, randBatSpawn);
                batList.add(bat);
                stage.addActor(bat);
                jumpImage.toFront();
                shootImage.toFront();
            }
        }
    }
}
