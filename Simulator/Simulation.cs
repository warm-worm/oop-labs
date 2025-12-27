namespace Simulator;

using Simulator.Maps;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables (creatures/animals) moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first object, second for second and so on.
    /// When all objects make moves,
    /// next move is again for first object and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    // prywatne pola do sledzenia stanu
    private List<Direction> _parsedMoves;
    private int _turnIndex = 0; // indeks obecnej tury

    /// <summary>
    /// Object (IMappable) which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => Mappables[_turnIndex % Mappables.Count]; // cykliczne wybieranie obiektu

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => _parsedMoves[_turnIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
        {
            throw new ArgumentException("Mappables list cannot be empty."); // lista nie moze byc pusta
        }

        if (positions == null || mappables.Count != positions.Count)
        {
            throw new ArgumentException("Number of mappables and positions must match."); // ilosc musi sie zgadzac
        }

        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = moves;

        _parsedMoves = DirectionParser.Parse(moves); // parsujemy ruchy

        // inicjalizacja obiektow na mapie
        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is finished.");
        }

        // wykonujemy ruch
        CurrentMappable.Go(_parsedMoves[_turnIndex]);

        _turnIndex++; // nastepna tura

        // sprawdzamy czy to byl ostatni ruch
        if (_turnIndex >= _parsedMoves.Count)
        {
            Finished = true;
        }
    }
}