using Content.Shared.Chat.TypingIndicator;
using Robust.Shared.Prototypes;

namespace Content.Shared._AS.Traits;

public sealed class ReplicantSystem : EntitySystem
{
    private static readonly ProtoId<TypingIndicatorPrototype> TypingIndicator = "robot";
    [Dependency] private readonly SharedTypingIndicatorSystem _typingIndicator = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ReplicantComponent, ComponentStartup>(OnReplicantStartup);
    }

    private void OnReplicantStartup(EntityUid uid, ReplicantComponent component, ComponentStartup args)
    {
        _typingIndicator.SetTypingIndicator(uid, TypingIndicator);
    }
}
