package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.math.Vector3;
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
import com.mygdx.game.entities.FloorEntity;
import com.mygdx.game.entities.PlayerEntity;
import com.mygdx.game.entities.RatEntity;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;
import java.util.Locale;

public class GameScreen extends BaseScreen {

    private Stage stage;
    private World world;

    private PlayerEntity player;

    private List<FloorEntity> floorList = new ArrayList<FloorEntity>();

    private List<RatEntity> ratList = new ArrayList<RatEntity>();

    private Music gameMusic, dieMusic;

    private Sound jump, ratSound;

    private Texture playerTexture, floorTexture, overfloorTexture, ratTexture, jumpTexture, shootTexture;

    private Vector3 camPos;

    private Label score;

    private Label.LabelStyle labelStyle;

    private BitmapFont font;

    private I18NBundle i18NBundle;

    private ImageButton jumpImage, shootImage;

    private Date date;

    private Calendar calendar;

    private String scoreFormat;

    private Float floorPos = 0f;

    private int cameraPosFloor = 0;

    public GameScreen(final MyMagoGame game) {
        super(game);
        stage = new Stage(new StretchViewport(840, 560));

        camPos = new Vector3(stage.getCamera().position);

        labelStyle = new Label.LabelStyle();
        font = new BitmapFont(Gdx.files.internal("GameFont.fnt"));
        labelStyle.font = font;
        labelStyle.fontColor = Color.WHITE;

//        i18NBundle = game.getManager().get("strings/strings.xml");
        score = new Label("Score:", labelStyle);

        score.setSize(score.getWidth() + 80, score.getHeight() + 50);
        score.setPosition(500, Gdx.graphics.getHeight());
        score.setAlignment(Align.right);

        world = new World(new Vector2(0, -10), true);

        gameMusic = game.getManager().get("GameSong.ogg");
        dieMusic = game.getManager().get("GameOver.ogg");
        jump = game.getManager().get("Jump.ogg");
        ratSound = game.getManager().get("Rat.ogg");

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
                player.jump();
            }
        });

        shootImage.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {

            }
        });


        world.setContactListener(new ContactListener() {

            private boolean areCollied(Contact contact, Object userA, Object userB) {
                return (contact.getFixtureA().getUserData().equals(userA) && contact.getFixtureB().getUserData().equals(userB)) || (contact.getFixtureA().getUserData().equals(userB) && contact.getFixtureB().getUserData().equals(userA));
            }

            @Override
            public void beginContact(Contact contact) {
                if (areCollied(contact, "player", "floor")) {
                    player.setJumping(false);
                    if (Gdx.input.isTouched()) {
                        player.setMustJump(true);
                    }
                }

                if (areCollied(contact, "player", "rat")) {
                    player.setAlive(false);
                    for (int i = 0; i < ratList.size(); i++) {
                        ratList.get(i).setDead(true);
                    }
                    gameMusic.stop();

                    dieMusic.play();

                    stage.addAction(Actions.sequence(Actions.delay(1), Actions.run(new Runnable() {
                        @Override
                        public void run() {
                            game.setScreen(game.gameOverScreen);
                        }
                    })));
                }

                if (areCollied(contact, "player", "leftBox")) {
                    player.setAlive(false);
                }
            }

            @Override
            public void endContact(Contact contact) {

            }

            @Override
            public void preSolve(Contact contact, Manifold oldManifold) {

            }

            @Override
            public void postSolve(Contact contact, ContactImpulse impulse) {

            }
        });
    }

    @Override
    public void show() {

        playerTexture = game.getManager().get("MagoStand.png");
        floorTexture = game.getManager().get("Floor.png");
        overfloorTexture = game.getManager().get("Overfloor.png");
        ratTexture = game.getManager().get("Rata.png");
        player = new PlayerEntity(world, playerTexture, new Vector2(1.5f, 1.5f));

        floorList.add(new FloorEntity(world, floorTexture, overfloorTexture, floorPos, 1, 1000));


        stage.addActor(player);
        stage.addActor(score);

        stage.getCamera().position.set(camPos);
        stage.getCamera().update();

        for (FloorEntity floor : floorList) {
            stage.addActor(floor);
        }
        for (RatEntity rat : ratList) {
            stage.addActor(rat);
        }
        stage.addActor(jumpImage);
        stage.addActor(shootImage);

        gameMusic.play();
    }

    @Override
    public void hide() {
        stage.clear();

        player.detach();
        for (FloorEntity floor : floorList) {
            floor.detach();
            floor.remove();
        }
        for (RatEntity rat : ratList) {
            rat.detach();
            rat.remove();
        }

        score.remove();

        floorList.clear();
        ratList.clear();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor(0.2f, 0.2f, 0.2f, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
        loadBackground();

        stage.act();
        world.step(delta, 6, 2);

        if (player.getX() > 150 && player.isAlive()) {
            stage.getCamera().translate(Constants.PLAYER_SPEED * delta * Constants.PIXELS_IN_METER, 0, 0);
        }

        score.setPosition(stage.getCamera().position.x + 200, score.getY());
        jumpImage.setPosition(stage.getCamera().position.x - 200, 0);
        shootImage.setPosition(stage.getCamera().position.x + 200, 0);

        if (Gdx.input.isTouched() && !player.isJumping()) {
            jump.play();
            player.jump();
        }

        stage.draw();
    }

    @Override
    public void dispose() {
        stage.dispose();
        world.dispose();
    }

    public void saveScore() {
        date = new Date();
        calendar = new GregorianCalendar();
        calendar.setTime(date);

        scoreFormat = calendar.get(Calendar.HOUR_OF_DAY) + ":" + calendar.get(Calendar.MINUTE);
    }
}
