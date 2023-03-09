package com.mygdx.game.scene2d;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Batch;
import com.badlogic.gdx.scenes.scene2d.Actor;

public class ActorMago extends Actor {

    private Texture mago;

    private  boolean alive;

    public  ActorMago(Texture mago) {
        this.mago = mago;
        this.alive = true;
        setSize(75,100);
    }

    @Override
    public void act(float delta) {

    }

    @Override
    public void draw(Batch batch, float parentAlpha) {
        batch.draw(mago,getX(),getY(),75,100);
    }

    public boolean isAlive() {
        return alive;
    }

    public void setAlive(boolean alive) {
        this.alive = alive;
    }
}
