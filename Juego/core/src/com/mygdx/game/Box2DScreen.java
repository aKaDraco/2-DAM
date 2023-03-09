package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.Box2DDebugRenderer;
import com.badlogic.gdx.physics.box2d.Contact;
import com.badlogic.gdx.physics.box2d.ContactImpulse;
import com.badlogic.gdx.physics.box2d.ContactListener;
import com.badlogic.gdx.physics.box2d.Fixture;
import com.badlogic.gdx.physics.box2d.Manifold;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;

public class Box2DScreen extends BaseScreen {

    public Box2DScreen(MyMagoGame game) {
        super(game);
    }

    private World world;

    private Box2DDebugRenderer renderer;

    private OrthographicCamera camera;

    private Body mago, suelo, rata;

    private Fixture magoFixture, sueloFixture, rataFixture;

    private boolean debeSaltar, magoJumping, magoVivo = true;

    @Override
    public void show() {
        world = new World(new Vector2(0, -10), true);
        renderer = new Box2DDebugRenderer();
        camera = new OrthographicCamera(21, 14);
        camera.translate(0, 4);

        world.setContactListener(new ContactListener() {
            @Override
            public void beginContact(Contact contact) {
                Fixture fixtureA = contact.getFixtureA(), fixtureB = contact.getFixtureB();

                if ((fixtureA.getUserData().equals("player") && fixtureB.getUserData().equals("floor")) ||
                        (fixtureA.getUserData().equals("floor") && fixtureB.equals("player"))) {
                    if (Gdx.input.isTouched()) {
                        debeSaltar = true;
                    }
                    magoJumping = false;
                }

                if ((fixtureA.getUserData().equals("player") && fixtureB.getUserData().equals("rata")) ||
                        (fixtureA.getUserData().equals("rata") && fixtureB.equals("player"))) {
                    magoVivo = false;
                }
            }

            @Override
            public void endContact(Contact contact) {
                Fixture fixtureA = contact.getFixtureA(), fixtureB = contact.getFixtureB();
                if (fixtureA == magoFixture && fixtureB == sueloFixture) {
                    magoJumping = true;
                }

                if (fixtureA == sueloFixture && fixtureB == magoFixture) {
                    magoJumping = true;
                }
            }

            @Override
            public void preSolve(Contact contact, Manifold oldManifold) {

            }

            @Override
            public void postSolve(Contact contact, ContactImpulse impulse) {

            }
        });

        mago = world.createBody(createMagoDef());
        suelo = world.createBody(createSueloDef());
        rata = world.createBody(createRataDef(1));

        PolygonShape magoShape = new PolygonShape();
        magoShape.setAsBox(0.7f, 1f);
        magoFixture = mago.createFixture(magoShape, 1);
        magoShape.dispose();

        PolygonShape sueloShape = new PolygonShape();
        sueloShape.setAsBox(500, 2);
        sueloFixture = suelo.createFixture(sueloShape, 1);
        sueloShape.dispose();

        PolygonShape rataShape = new PolygonShape();
        rataShape.setAsBox(0.5f, 0.3f);
        rataFixture = rata.createFixture(rataShape, 1);
        rataShape.dispose();

        magoFixture.setUserData("player");
        sueloFixture.setUserData("floor");
        rataFixture.setUserData("rata");
    }

    private BodyDef createRataDef(float x) {
        BodyDef def = new BodyDef();
        def.position.set(x, 1.3f);
        return def;
    }

    private BodyDef createSueloDef() {
        BodyDef def = new BodyDef();
        def.position.set(0, -1);
        return def;
    }

    private BodyDef createMagoDef() {
        BodyDef def = new BodyDef();
        def.position.set(-6, 2);
        def.type = BodyDef.BodyType.DynamicBody;
        return def;
    }

    @Override
    public void dispose() {
        rata.destroyFixture(rataFixture);
        suelo.destroyFixture(sueloFixture);
        mago.destroyFixture(magoFixture);
        world.destroyBody(rata);
        world.destroyBody(suelo);
        world.destroyBody(mago);
        world.dispose();
        renderer.dispose();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        if (debeSaltar) {
            debeSaltar = false;
            saltar();
        }

        if (Gdx.input.justTouched() && !magoJumping) {
            debeSaltar = true;
        }

        if (magoVivo) {
            float velocidadY = mago.getLinearVelocity().y;
            mago.setLinearVelocity(2, velocidadY);
        }

        world.step(delta, 6, 2);

        camera.update();
        renderer.render(world, camera.combined);
    }

    private void saltar() {
        Vector2 position = mago.getPosition();
        mago.applyLinearImpulse(0, 20, position.x, position.y, true);
    }
}
