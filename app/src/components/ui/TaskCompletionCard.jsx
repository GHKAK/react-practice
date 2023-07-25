function TaskCompletionCard({value, isCompleted}){
    return (
    <div className="card task-card">
    <div className={`card-icon icon-box ${isCompleted?'green':'blue'}`}>
      <span className="material-symbols-rounded  icon">{isCompleted?"task_alt":"drive_file_rename_outline"}</span>
    </div>
    <div>
      <data className="card-data" value={value}>
        {value}
      </data>
      <p className="card-text">Tasks {isCompleted?"Completed":"Inprogress"}</p>
    </div>
  </div>);
}
export default TaskCompletionCard;