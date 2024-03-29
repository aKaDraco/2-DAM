<?php

namespace App\Http\Controllers;

use App\Models\Categoria;
use App\Models\Juego;
use Illuminate\Http\Request;

/**
 * Class JuegoController
 * @package App\Http\Controllers
 */
class JuegoController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $juegos = Juego::paginate();

        return view('juego.index', compact('juegos'))
            ->with('i', (request()->input('page', 1) - 1) * $juegos->perPage());
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        $juego = new Juego();
        $categorias = Categoria::pluck('nombre', 'id');
        return view('juego.create', compact('juego', 'categorias'));
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        request()->validate(Juego::$rules);

        $juego = Juego::create($request->all());

        return redirect()->route('juegos.index')
            ->with('success', 'Juego created successfully.');
    }

    /**
     * Display the specified resource.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        $juego = Juego::find($id);

        return view('juego.show', compact('juego'));
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        $juego = Juego::find($id);
        $categorias = Categoria::pluck('nombre', 'id');

        return view('juego.edit', compact('juego','categorias'));
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request $request
     * @param  Juego $juego
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Juego $juego)
    {
        request()->validate(Juego::$rules);

        $juego->update($request->all());

        return redirect()->route('juegos.index')
            ->with('success', 'Juego updated successfully');
    }

    /**
     * @param int $id
     * @return \Illuminate\Http\RedirectResponse
     * @throws \Exception
     */
    public function destroy($id)
    {
        $juego = Juego::find($id)->delete();

        return redirect()->route('juegos.index')
            ->with('success', 'Juego deleted successfully');
    }
}
