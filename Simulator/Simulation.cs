namespace Simulator;

using Simulator.Maps;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves,
    /// next move is again for first creature and so on.
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
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_turnIndex % Creatures.Count]; // cykliczne wybieranie stwora

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => _parsedMoves[_turnIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("Creatures list cannot be empty."); // lista nie moze byc pusta
        }

        if (positions == null || creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures and positions must match."); // ilosc musi sie zgadzac
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        _parsedMoves = DirectionParser.Parse(moves); // parsujemy ruchy

        // inicjalizacja stworow na mapie
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is finished.");
        }

        // wykonujemy ruch
        CurrentCreature.Go(_parsedMoves[_turnIndex]);

        _turnIndex++; // nastepna tura

        // sprawdzamy czy to byl ostatni ruch
        if (_turnIndex >= _parsedMoves.Count)
        {
            Finished = true;
        }
    }
}