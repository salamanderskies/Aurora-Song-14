using Content.Shared.Body.Systems;
using Content.Shared.Chemistry.Components;

namespace Content.Shared._AS.Traits;

/// <summary>
/// System that handles swapping blood reagents. Used with <see cref="BloodSwapComponent"/>.
/// </summary>
public sealed class BloodSwapSystem : EntitySystem
{
    [Dependency] private readonly SharedBloodstreamSystem _bloodSystem = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<BloodSwapComponent, ComponentStartup>(OnBloodSwapStartup);
    }

    private void OnBloodSwapStartup(EntityUid uid, BloodSwapComponent component, ComponentStartup args)
    {
        // Solution made from the reagent defined in BloodSwapComponent
        Solution bloodSolution = new([new(component.BloodReagent, 300)]);

        _bloodSystem.ChangeBloodReagents(uid, bloodSolution);
    }
}
