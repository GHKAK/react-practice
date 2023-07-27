import RecentProjectItem from "./RecentProjectItem";
import ViewAllButton from "./ViewAllButton";

function RecentProjects() {
  return (
    <>
      <div className="section-title-wrapper">
        <h2 className="section-title">Recent Projects</h2>
        <ViewAllButton />
      </div>
      <ul className="project-list">
        <RecentProjectItem
          date="2022-04-09"
          title="Shreyu - Design Updates"
          stage="Designing"
          description="Update shreyu with modern and latest trends..."
          progressPercentage={75}
        />
        <RecentProjectItem
          date="2022-04-09"
          title="Prompt v2.0"
          stage="Planning"
          description="Plan new features and functionality for prompt..."
          progressPercentage={60}
        />
        <RecentProjectItem
          date="2022-04-09"
          title="Hyper React v4.0"
          stage="Development"
          description="Update shreyu with modern and latest trends..."
          progressPercentage={40}
        />
      </ul>
    </>
  );
}
export default RecentProjects;
