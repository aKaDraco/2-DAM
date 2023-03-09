package com.mygdx.game;

import com.badlogic.gdx.Game;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.scenes.scene2d.ui.Image;
import com.badlogic.gdx.utils.I18NBundle;

import java.awt.Font;
import java.io.File;

public class MyMagoGame extends Game {

    private AssetManager manager;

    public GameScreen gameScreen;

    public GameOverScreen gameOverScreen;

    public MenuScreen menuScreen;

    public LoadingScreen loadingScreen;

    public RankingScreen rankingScreen;

    public OptionsScreen optionsScreen;

    public AssetManager getManager() {
        return manager;
    }

    @Override
    public void create() {
        manager = new AssetManager();
        manager.load("Armor.png", Texture.class);
        manager.load("Blackcard.png", Texture.class);
        manager.load("Black card moving.png", Texture.class);
        manager.load("Bloque Mejora.png", Texture.class);
        manager.load("Floor.png", Texture.class);
        manager.load("Overfloor.png", Texture.class);
        manager.load("Fireball.png", Texture.class);
        manager.load("MagoMoving1.png", Texture.class);
        manager.load("MagoMoving2.png", Texture.class);
        manager.load("MagoMoving3.png", Texture.class);
        manager.load("MagoStand.png", Texture.class);
        manager.load("Murcielago.png", Texture.class);
        manager.load("Murcielago2.png", Texture.class);
        manager.load("Murcielago3.png", Texture.class);
        manager.load("Murcielago4.png", Texture.class);
        manager.load("Murcielago5.png", Texture.class);
        manager.load("Rata.png", Texture.class);
        manager.load("Rata Moving.png", Texture.class);
        manager.load("Serpiente.png", Texture.class);
        manager.load("Serpiente2.png", Texture.class);
        manager.load("Serpiente3.png", Texture.class);
        manager.load("Vida.png", Texture.class);
        manager.load("White card.png", Texture.class);
        manager.load("White card moving.png", Texture.class);
        manager.load("Murcielago Jefe.png", Texture.class);
        manager.load("Murcielago Jefe2.png", Texture.class);
        manager.load("Murcielago Jefe3.png", Texture.class);
        manager.load("Murcielago Jefe4.png", Texture.class);
        manager.load("Murcielago Jefe5.png", Texture.class);
        manager.load("GameOver.ogg", Music.class);
        manager.load("GameSong.ogg", Music.class);
        manager.load("Jump.ogg", Sound.class);
        manager.load("Rat.ogg", Sound.class);
        manager.load("Game Over.png", Texture.class);
        manager.load("RetryButton.png", Texture.class);
        manager.load("MenuButton.png", Texture.class);
        manager.load("Titulo.png", Texture.class);
        manager.load("PlayButton.png", Texture.class);
        manager.load("QuitButton.png", Texture.class);
        manager.load("RankingButton.png", Texture.class);
        manager.load("OptionsButton.png", Texture.class);
        manager.load("SalirButton.png", Texture.class);
        manager.load("OpcionesButton.png", Texture.class);
        manager.load("JugarButton.png", Texture.class);
        manager.load("Cargando.png", Texture.class);
        manager.load("Loading.png", Texture.class);
        manager.load("GameFont.fnt", BitmapFont.class);
        manager.load("ShootButton.png",Texture.class);
        manager.load("DisparoButton.png",Texture.class);
        manager.load("JumpButton.png",Texture.class);
        manager.load("SaltoButton.png",Texture.class);
        manager.load("Scream.ogg",Sound.class);


//        manager.load("strings/strings.xml", I18NBundle.class);


        loadingScreen = new LoadingScreen(this);
        setScreen(loadingScreen);
    }

    public void finishLoading() {
        menuScreen = new MenuScreen(this);
        gameScreen = new GameScreen(this);
        rankingScreen = new RankingScreen(this);
        gameOverScreen = new GameOverScreen(this);
        optionsScreen = new OptionsScreen(this);
        setScreen(menuScreen);
    }
}
