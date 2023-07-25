import TaskCompletionCard from "./TaskCompletionCard";

function TasksCompletionsWrapper(){
    return (
    <div className="card-wrapper">
        <TaskCompletionCard value={21} isCompleted/>
        <TaskCompletionCard value={21} />
    </div>);
}
export default TasksCompletionsWrapper;