package com.mygdx.game.entities;

import static com.mygdx.game.Constants.*;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Batch;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.Fixture;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.Actor;

public class CardEntity extends Actor {

    private Texture texture;

    private World world;

    public Body getBody() {
        return body;
    }

    public void setBody(Body body) {
        this.body = body;
    }

    private Body body;

    private Fixture fixture;

    private boolean cardMoving = true;

    public boolean isCardMoving() {
        return cardMoving;
    }

    public void setCardMoving(boolean cardMoving) {
        this.cardMoving = cardMoving;
    }

    public CardEntity(World world, Texture texture, float x, float y) {
        this.world = world;
        this.texture = texture;

        BodyDef def = new BodyDef();
        def.position.set(x, y);
        def.type = BodyDef.BodyType.DynamicBody;
        body = world.createBody(def);

        PolygonShape box = new PolygonShape();
        box.setAsBox(0.35f, 0.05f);
        fixture = body.createFixture(box, 2);
        fixture.setUserData("card");
        box.dispose();

        body.setGravityScale(0);

        setSize(PIXELS_IN_METER, PIXELS_IN_METER * 0.6f);
    }

    @Override
    public void draw(Batch batch, float parentAlpha) {
        setPosition((body.getPosition().x - 0.5f) * PIXELS_IN_METER,
                (body.getPosition().y - 0.5f) * PIXELS_IN_METER);
        if (texture != null) {
            batch.draw(texture, getX(), getY(), getWidth(), getHeight());
        }
    }

    public void detach() {
        body.destroyFixture(fixture);
        world.destroyBody(body);
    }

    @Override
    public void act(float delta) {
//        if (!cardMoving) {
//            body.setActive(false);
//            setSize(0, 0);
//            body.setLinearVelocity(0, 0);
//            // world.destroyBody(body);
//        } else {
            body.setLinearVelocity(6, body.getLinearVelocity().y);

    }
}