import LoadMoreButton from "./LoadMoreButton";
import TaskCard from "./TaskCard";
import ViewAllButton from "./ViewAllButton";

function Tasks() {
  return (
    <>
      <div className="section-title-wrapper">
        <h2 className="section-title">Tasks</h2>
        <ViewAllButton />
      </div>
      <ul className="tasks-list">
        <TaskCard task="Draft the new contract document for sales team" deadline = "Today 10pm" progress="3/7" commentsCount={21} priority="High"/>
        <TaskCard task="iOS App home page design" deadline = "Today 5pm" progress="3/7" commentsCount={21} priority="Medium"/>
        <TaskCard task="Enable analytics tracking" deadline = "Tomorrow 5pm" progress="3/7" commentsCount={21} priority="Medium"/>
        <TaskCard task="Kanban board design" deadline = "Sep 11, 3pm" progress="3/7" commentsCount={21} priority="Low"/>
      </ul>
      <LoadMoreButton />
    </>
  );
}
export default Tasks;
