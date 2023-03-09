package com.mygdx.game;

import static com.mygdx.game.Constants.MID_SCREEN;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Preferences;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.scenes.scene2d.Actor;
import com.badlogic.gdx.scenes.scene2d.InputEvent;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.CheckBox;
import com.badlogic.gdx.scenes.scene2d.ui.ImageButton;
import com.badlogic.gdx.scenes.scene2d.ui.Label;
import com.badlogic.gdx.scenes.scene2d.utils.ChangeListener;
import com.badlogic.gdx.scenes.scene2d.utils.ClickListener;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.Align;
import com.badlogic.gdx.utils.viewport.StretchViewport;

import java.util.Locale;

public class OptionsScreen extends BaseScreen {
    private Stage stage;

    private Label volume, vibration, aceleration;

    private Label.LabelStyle labelStyleVolume, labelStyleVibration, labelStyleAceleration;

    private BitmapFont font;

    public boolean offVolume = false, offVibration = false, offAceleration = false;

    private Texture quitTexture;

    private ImageButton quitButton;

    public OptionsScreen(final MyMagoGame game) {
        super(game);
        stage = new Stage(new StretchViewport(840, 560));

        labelStyleVolume = new Label.LabelStyle();
        labelStyleVibration = new Label.LabelStyle();
        labelStyleAceleration = new Label.LabelStyle();
        font = new BitmapFont(Gdx.files.internal("GameFont.fnt"));
        font.getData().setScale(3);

        labelStyleVolume.font = font;
        labelStyleVibration.font = font;
        labelStyleAceleration.font = font;

        labelStyleVolume.fontColor = Color.LIME;
        labelStyleVibration.fontColor = Color.LIME;
        labelStyleAceleration.fontColor = Color.LIME;

        if (Locale.getDefault().equals(new Locale("es", "ES"))) {
            volume = new Label("VOLUMEN", labelStyleVolume);
            vibration = new Label("VIBRACION", labelStyleVibration);
            aceleration = new Label("ACELEROMETRO", labelStyleAceleration);
            quitTexture = new Texture(Gdx.files.internal("SalirButton.png"));
        } else {
            volume = new Label("VOLUME", labelStyleVolume);
            vibration = new Label("VIBRATION", labelStyleVibration);
            aceleration = new Label("ACELEROMETER", labelStyleAceleration);
            quitTexture = new Texture(Gdx.files.internal("QuitButton.png"));
        }

        quitButton = new ImageButton(new TextureRegionDrawable(new TextureRegion(quitTexture)));
        quitButton.addCaptureListener(new ChangeListener() {
            @Override
            public void changed(ChangeEvent event, Actor actor) {
                game.setScreen(game.menuScreen);
            }
        });

        volume.setPosition(MID_SCREEN - volume.getWidth() / 2, 360 - volume.getHeight() / 2);
        vibration.setPosition(MID_SCREEN - vibration.getWidth() / 2, 280 - vibration.getHeight() / 2);
        aceleration.setPosition(MID_SCREEN - aceleration.getWidth() / 2, 200 - aceleration.getHeight() / 2);
        quitButton.setPosition(MID_SCREEN - quitButton.getWidth() / 2, 100 - quitButton.getHeight() / 2);

        volume.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                offVolume = !offVolume;
                if (offVolume) {
                    labelStyleVolume.fontColor = Color.RED;
                } else {
                    labelStyleVolume.fontColor = Color.LIME;
                }
            }
        });

        vibration.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                offVibration = !offVibration;
                if (offVibration) {
                    labelStyleVibration.fontColor = Color.RED;
                } else {
                    labelStyleVibration.fontColor = Color.LIME;
                }
            }
        });

        aceleration.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                offAceleration = !offAceleration;
                if (offAceleration) {
                    labelStyleAceleration.fontColor = Color.RED;
                } else {
                    labelStyleAceleration.fontColor = Color.LIME;
                }
            }
        });
    }

    @Override
    public void show() {
        Gdx.input.setInputProcessor(stage);

        stage.addActor(volume);
        stage.addActor(vibration);
        stage.addActor(aceleration);
        stage.addActor(quitButton);
    }

    @Override
    public void hide() {
        Gdx.input.setInputProcessor(null);
        volume.remove();
        vibration.remove();
        aceleration.remove();
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
