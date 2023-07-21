function ProgressBar({ value, isPercentage }) {
  const percentageValue = isPercentage ? value:  value*10;
  const red = 255 - percentageValue * 2.55;
  const green = percentageValue * 2.55;
  const barColor = `rgb(${red}, ${green}, 0)`;
  return (
    <>
      <div className="progress-label">
        <p className="progress-title">Project Completion</p>
        <data className="progress-data" value={value}>
          {value}
          {isPercentage ? "%" : ""}
        </data>
      </div>
      <div className="progress-bar">
        <div
          className="progress"
          style={{ "--width": `${percentageValue}%`, "--bg": barColor }}
        />
      </div>
    </>
  );
}
export default ProgressBar;
