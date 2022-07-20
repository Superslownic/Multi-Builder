using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Multi.Builder
{
    public class MultiBuilder : OdinEditorWindow
    {
        [MenuItem("Tools/Multi Builder")]
        private static void OpenWindow()
        {
            GetWindow<MultiBuilder>().Show();
        }

        [Title("Profile")]
        [ShowInInspector, HideLabel] private BuildProfile _profile;

        [PropertySpace]
        [Button, ShowIf(nameof(_profile))]
        public void Build()
        {
            var settings = RunInstructions();
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, settings.FullPath, settings.BuildTarget, settings.BuildOptions);
        }

        [Button, ShowIf(nameof(_profile))]
        public void BuildAndRun()
        {
            var settings = RunInstructions();
            settings.BuildOptions |= BuildOptions.AutoRunPlayer;
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, settings.FullPath, settings.BuildTarget, settings.BuildOptions);
        }

        private BuildSettings RunInstructions()
        {
            var settings = new BuildSettings();
            foreach (IBuildInstruction instruction in _profile.Instructions)
                instruction.Process(settings);
            return settings;
        }
    }
}