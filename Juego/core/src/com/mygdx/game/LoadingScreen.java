package com.mygdx.game;

import static com.mygdx.game.Constants.DIVIDE;
import static com.mygdx.game.Constants.MID_SCREEN;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.Image;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.viewport.StretchViewport;

import java.util.ArrayList;
import java.util.Locale;

public class LoadingScreen extends BaseScreen {

    private Stage stage;

    private Texture loadingTexture, cargandoTexture;

    private Image loadingImage, cargandoImage;

    private ArrayList<Texture> magoTextures;

    private ArrayList<Image> magoImages;

    private int actorsCount;

    private float fixed_time;

    private float accumulator;

    private int imageIndex;

    public LoadingScreen(MyMagoGame game) {
        super(game);

        stage = new Stage(new StretchViewport(840, 560));

        fixed_time = 0.3f;
        accumulator = 0;
        imageIndex = 0;
        magoTextures = new ArrayList<Texture>();
        magoImages = new ArrayList<Image>();

        for (int i = 1; i <= 3; i++) {
            magoTextures.add(new Texture(Gdx.files.internal("MagoMoving" + i + ".png")));
        }

        for (int j = 0; j < 3; j++) {
            magoImages.add(new Image(new TextureRegionDrawable(new TextureRegion(magoTextures.get(j)))));
            magoImages.get(j).setPosition(MID_SCREEN - magoImages.get(j).getWidth() - 50 / 2, MID_SCREEN - magoImages.get(j).getWidth() - 300 / 2);
            magoImages.get(j).setSize(100, 200);
        }


        if (Locale.getDefault().equals(new Locale("es", "ES"))) {
            cargandoTexture = new Texture(Gdx.files.internal("Cargando.png"));
            cargandoImage = new Image(new TextureRegionDrawable(new TextureRegion(cargandoTexture)));
            cargandoImage.setPosition(MID_SCREEN - cargandoImage.getWidth() / 2, MID_SCREEN - cargandoImage.getWidth() + DIVIDE / 2);

            stage.addActor(cargandoImage);

        } else {
            loadingTexture = new Texture(Gdx.files.internal("Loading.png"));
            loadingImage = new Image(new TextureRegionDrawable(new TextureRegion(loadingTexture)));
            loadingImage.setPosition(MID_SCREEN - loadingImage.getWidth() / 2, MID_SCREEN - loadingImage.getWidth() + DIVIDE / 2);

            stage.addActor(loadingImage);
        }

        actorsCount = stage.getActors().size;
    }

    @Override
    public void render(float delta) {

        Gdx.gl.glClearColor(0, 0, 0, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);


        accumulator += delta;


        if (game.getManager().update()) {
            game.finishLoading();
        } else {
            stage.addActor(magoImages.get(imageIndex));
            if (fixed_time < accumulator) {
                accumulator = 0;
                stage.getActors().get(imageIndex + actorsCount).setVisible(false);
                imageIndex++;
                if (imageIndex > 2) {
                    imageIndex = 0;
                } else {
                    stage.addActor(magoImages.get(imageIndex));
                }
                stage.getActors().get(imageIndex + actorsCount).setVisible(true);
            }
        }

        loadBackground();

        stage.act();
        stage.draw();
    }

    @Override
    public void dispose() {
        stage.dispose();
    }
}
