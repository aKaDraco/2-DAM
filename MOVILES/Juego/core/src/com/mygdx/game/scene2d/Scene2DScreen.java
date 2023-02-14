package com.mygdx.game.scene2d;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.mygdx.game.BaseScreen;
import com.mygdx.game.MyMagoGame;

public class Scene2DScreen extends BaseScreen {

    public Scene2DScreen(MyMagoGame game) {
        super(game);
        texturaMago = new Texture("Mago Stand.png");
        texturaRata = new Texture("Rata.png");
    }

    private Stage stage;

    private ActorMago mago;
    private ActorRata rata;

    private Texture texturaMago, texturaRata;

    @Override
    public void show() {
        stage = new Stage();
        stage.setDebugAll(true);

        mago = new ActorMago(texturaMago);
        rata = new ActorRata(texturaRata);
        stage.addActor(mago);
        stage.addActor(rata);

        mago.setPosition(20, 100);
        rata.setPosition(500, 100);
    }

    @Override
    public void hide() {
        stage.dispose();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor(0.2f, 0.2f, 0.2f, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);


        stage.act();

        comprobarColisiones();

        stage.draw();
    }

    private void comprobarColisiones() {
        if (mago.isAlive() && (mago.getX() + mago.getWidth()) > rata.getX()) {
            System.out.println("COLISION");
            mago.setAlive(false);
        }
    }

    @Override
    public void dispose() {
        texturaMago.dispose();
    }
}
