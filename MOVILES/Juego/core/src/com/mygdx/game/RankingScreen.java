package com.mygdx.game;

import static com.mygdx.game.Constants.MID_SCREEN;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.files.FileHandle;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.scenes.scene2d.Actor;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.ImageButton;
import com.badlogic.gdx.scenes.scene2d.ui.Label;
import com.badlogic.gdx.scenes.scene2d.utils.ChangeListener;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.Align;
import com.badlogic.gdx.utils.viewport.StretchViewport;
import com.mygdx.game.entities.FloorEntity;

import java.util.Locale;

public class RankingScreen extends BaseScreen {

    private Stage stage;

    private Label score;

    private Label.LabelStyle labelStyle;

    private BitmapFont font;

    private FileHandle fileHandle;

    private String scorePoints;

    private Texture quitTexture;

    private ImageButton quitButton;

    public RankingScreen(final MyMagoGame game) {
        super(game);
        stage = new Stage(new StretchViewport(840, 560));
        fileHandle = Gdx.files.internal("Ranking.txt");
        scorePoints = fileHandle.readString();

        labelStyle = new Label.LabelStyle();
        font = new BitmapFont(Gdx.files.internal("GameFont.fnt"));
        font.getData().setScale(2);
        labelStyle.font = font;
        labelStyle.fontColor = Color.WHITE;

        score = new Label(scorePoints, labelStyle);
        score.setPosition(Gdx.graphics.getWidth() - 440, Gdx.graphics.getHeight() - 110);
        score.setSize(font.getScaleX(), font.getScaleY());
        score.setAlignment(Align.center);

        if (Locale.getDefault().equals(new Locale("es", "ES"))) {
            quitTexture = new Texture(Gdx.files.internal("SalirButton.png"));
        } else {
            quitTexture = new Texture(Gdx.files.internal("QuitButton.png"));
        }

        quitButton = new ImageButton(new TextureRegionDrawable(new TextureRegion(quitTexture)));
        quitButton.setPosition(MID_SCREEN - quitButton.getWidth() / 2, 50 - quitButton.getHeight() / 2);

        quitButton.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.menuScreen);
            }
        });
    }

    @Override
    public void show() {
        Gdx.input.setInputProcessor(stage);

        stage.addActor(score);
        stage.addActor(quitButton);

//        while (player.isAlive()) {
//            cameraPosFloor++;
//            if (cameraPosFloor >= 950) {
//                cameraPosFloor = 0;
//                if (cameraPosFloor == 0) {
//                    floorPos = 950f;
//                    floorList.add(new FloorEntity(world, floorTexture, overfloorTexture, floorPos, 1, 1000));
//                }
//            }
//        }
    }

    @Override
    public void hide() {
        Gdx.input.setInputProcessor(null);
        score.remove();
        quitButton.remove();
        stage.clear();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor(0.02f, 0, 0, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        loadBackground();

        stage.act();
        stage.draw();
    }

    @Override
    public void dispose() {
        quitTexture.dispose();
        stage.dispose();
    }
}
