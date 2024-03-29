package com.mygdx.game.entities;

import static com.mygdx.game.Constants.*;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Batch;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.Fixture;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.Actor;

public class FloorEntity extends Actor {

    private Texture floor, overfloor;

    private World world;

    private Body body, leftBody;

    private Fixture fixture, leftFixture;


    public FloorEntity(World world, Texture floor, Texture overfloor, float x, float y, float width) {
        this.world = world;
        this.floor = floor;
        this.overfloor = overfloor;

        BodyDef def = new BodyDef();
        def.position.set(x + width / 2, y - 0.5f);
        body = world.createBody(def);

        PolygonShape box = new PolygonShape();
        box.setAsBox(width / 2, 0.9f);
        fixture = body.createFixture(box, 1);
        fixture.setUserData("floor");
        box.dispose();

        BodyDef leftDef = new BodyDef();
        leftDef.position.set(x, y - 0.55f);
        body = world.createBody(leftDef);

        PolygonShape leftBox = new PolygonShape();
        leftBox.setAsBox(0.02f, 0.45f);
        fixture = body.createFixture(leftBox, 1);
        fixture.setUserData("leftBox");
        leftBox.dispose();

        BodyDef rightDef = new BodyDef();
        rightDef.position.set(x + width, y - 0.55f);
        body = world.createBody(rightDef);

        PolygonShape rightBox = new PolygonShape();
        rightBox.setAsBox(0.05f, 0.5f);
        fixture = body.createFixture(rightBox, 1);
        fixture.setUserData("rightBox");
        rightBox.dispose();

        setSize(width * PIXELS_IN_METER, PIXELS_IN_METER);
        setPosition(x * PIXELS_IN_METER, (y - 1) * PIXELS_IN_METER);
    }

    @Override
    public void draw(Batch batch, float parentAlpha) {
        batch.draw(floor, getX(), getY(), getWidth(), getHeight());
        batch.draw(overfloor, getX(), getY(), getWidth(), getHeight());
    }

    public void detach() {
        body.destroyFixture(fixture);
        world.destroyBody(body);
    }
}