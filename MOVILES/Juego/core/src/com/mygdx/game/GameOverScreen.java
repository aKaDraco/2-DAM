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
import com.badlogic.gdx.utils.viewport.FitViewport;
import com.badlogic.gdx.utils.viewport.StretchViewport;

public class GameOverScreen extends BaseScreen {

    private Stage stage;

    private ImageButton retry, menu;

    private Image gameOver;

    private Texture retryTexture, menuTexture;

    public GameOverScreen(final MyMagoGame game) {
        super(game);

        stage = new Stage(new StretchViewport(840, 560));

        retryTexture = new Texture(Gdx.files.internal("RetryButton.png"));
        menuTexture = new Texture(Gdx.files.internal("MenuButton.png"));
        gameOver = new Image(game.getManager().get("Game Over.png", Texture.class));
        retry = new ImageButton(new TextureRegionDrawable(new TextureRegion(retryTexture)));
        menu = new ImageButton(new TextureRegionDrawable(new TextureRegion(menuTexture)));

        retry.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.gameScreen);
            }
        });

        menu.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.menuScreen);
            }
        });

        gameOver.setSize(450, 200);

        gameOver.setPosition(MID_SCREEN - gameOver.getWidth() / 2, MID_SCREEN - gameOver.getHeight() / 2);
        retry.setPosition(550 - gameOver.getWidth() / 2, 220 - gameOver.getHeight() / 2);
        menu.setPosition(550 - gameOver.getWidth() / 2, 120 - gameOver.getHeight() / 2);

        stage.addActor(gameOver);
        stage.addActor(retry);
        stage.addActor(menu);
    }

    @Override
    public void show() {
        Gdx.input.setInputProcessor(stage);
    }

    @Override
    public void hide() {
        Gdx.input.setInputProcessor(null);
    }

    @Override
    public void dispose() {
        stage.dispose();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor(0.02f, 0, 0, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        loadBackground();

        stage.act();
        stage.draw();
    }
}
