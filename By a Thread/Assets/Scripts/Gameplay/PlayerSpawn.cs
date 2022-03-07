using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            
            // idk why but having this code in playerDeath gives incorrect values
            if (player == model.player) 
            {
                model.DeathCount += 1;
            }
            
            //player.collider2d.enabled = true;
            player.controlEnabled = false;
            //if (player.audioSource && player.respawnAudio)
            //    player.audioSource.PlayOneShot(player.respawnAudio);
            player.health += 1;
            player.Teleport(model.spawnPoint.transform.position);
            //player.jumpState = PlayerController.JumpState.Grounded;
            //player.animator.SetBool("dead", false);
            Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}