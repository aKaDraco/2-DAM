package com.mygdx.game;

import static com.mygdx.game.Constants.MID_SCREEN;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.scenes.scene2d.Actor;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.Image;
import com.badlogic.gdx.scenes.scene2d.ui.ImageButton;
import com.badlogic.gdx.scenes.scene2d.utils.ChangeListener;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.viewport.StretchViewport;

import java.util.Locale;

public class MenuScreen extends BaseScreen {

    private Stage stage;

    private Image titulo;

    private Texture playTexture, rankingTexture, optionsTexture, quitTexture;

    private ImageButton playButton, rankingButton, optionsButton, quitButton;

    public MenuScreen(final MyMagoGame game) {
        super(game);

        stage = new Stage(new StretchViewport(840, 560));

        if (Locale.getDefault().equals(new Locale("es", "ES"))) {
            titulo = new Image(game.getManager().get("Titulo.png", Texture.class));
            playTexture = new Texture(Gdx.files.internal("JugarButton.png"));
            rankingTexture = new Texture(Gdx.files.internal("RankingButton.png"));
            optionsTexture = new Texture(Gdx.files.internal("OpcionesButton.png"));
            quitTexture = new Texture(Gdx.files.internal("SalirButton.png"));
        } else {
            titulo = new Image(game.getManager().get("Titulo.png", Texture.class));
            playTexture = new Texture(Gdx.files.internal("PlayButton.png"));
            rankingTexture = new Texture(Gdx.files.internal("RankingButton.png"));
            optionsTexture = new Texture(Gdx.files.internal("OptionsButton.png"));
            quitTexture = new Texture(Gdx.files.internal("QuitButton.png"));
        }

        playButton = new ImageButton(new TextureRegionDrawable(new TextureRegion(playTexture)));
        rankingButton = new ImageButton(new TextureRegionDrawable(new TextureRegion(rankingTexture)));
        optionsButton = new ImageButton(new TextureRegionDrawable(new TextureRegion(optionsTexture)));
        quitButton = new ImageButton(new TextureRegionDrawable(new TextureRegion(quitTexture)));

        playButton.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.gameScreen);
            }
        });

        rankingButton.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.rankingScreen);
            }
        });

        optionsButton.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.optionsScreen);
            }
        });

        quitButton.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                System.exit(0);
            }
        });

        titulo.setSize(450, 200);
        titulo.setPosition(MID_SCREEN - titulo.getWidth() / 2, 470 - titulo.getHeight() / 2);
        playButton.setPosition(MID_SCREEN - playButton.getWidth() / 2, 350 - playButton.getHeight() / 2);
        rankingButton.setPosition(MID_SCREEN - rankingButton.getWidth() / 2, 250 - rankingButton.getHeight() / 2);
        optionsButton.setPosition(MID_SCREEN - optionsButton.getWidth() / 2, 150 - optionsButton.getHeight() / 2);
        quitButton.setPosition(MID_SCREEN - quitButton.getWidth() / 2, 50 - quitButton.getHeight() / 2);
    }

    @Override
    public void show() {
        Gdx.input.setInputProcessor(stage);

        stage.addActor(titulo);
        stage.addActor(playButton);
        stage.addActor(rankingButton);
        stage.addActor(optionsButton);
        stage.addActor(quitButton);
    }

    @Override
    public void hide() {
        Gdx.input.setInputProcessor(null);

        titulo.remove();
        playButton.remove();
        rankingButton.remove();
        optionsButton.remove();
        quitButton.remove();
        stage.clear();
    }

    @Override
    public void dispose() {
        playTexture.dispose();
        rankingTexture.dispose();
        rankingTexture.dispose();
        optionsTexture.dispose();
        quitTexture.dispose();
        stage.dispose();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor(0, 0, 0, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        loadBackground();

        stage.act();
        stage.draw();
    }
}
