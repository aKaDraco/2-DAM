package com.mygdx.game.scene2d;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Batch;
import com.badlogic.gdx.scenes.scene2d.Actor;

public class ActorRata extends Actor {

    private Texture rata;

    public ActorRata(Texture rata) {
        this.rata = rata;
        setSize(70,40);
    }

    @Override
    public void act(float delta) {
        setX(getX() - 250 * delta);
    }

    @Override
    public void draw(Batch batch, float parentAlpha) {
        batch.draw(rata, getX(), getY(), 70, 40);
    }
}
