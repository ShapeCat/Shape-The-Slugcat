internal class ShapeStart : UpdatableAndDeletable
{
    public ShapeStart(Room startRoom)
    {
        room = startRoom;
    }

    public Player Shape => (room.game.Players.Count <= 0) ? null : (room.game.Players[0].realizedCreature as Player);
    private int timer = 0;
    

    public override void Update(bool eu)
    {

        if (Shape == null) return;
        base.Update(eu);

        Shape.SetMalnourished(true);

        for (int i = 0; i < 2; i++)
        {
            Shape.bodyChunks[i].HardSetPosition(room.MiddleOfTile(10, 14));
            Shape.bodyChunks[i].vel = new UnityEngine.Vector2(0, 0);
        }

        if (timer == 40)
        {
            Shape.bodyChunks[0].vel = new UnityEngine.Vector2(0, 0);
            Shape.bodyChunks[1].vel = new UnityEngine.Vector2(0, 0);
            Destroy();
        }
        timer++;
    }
}
