import TrendingDownSymbol from "./TrendingDownSymbol";
import TrendingUpSymbol from "./TrendingUpSymbol";

function RevenueFigure({ period, value }) {
  const percentageValue = Math.abs(Math.round(value * 100-100));
  return (
    <li className="revenue-item icon-box">
      {value > 1 ? <TrendingUpSymbol /> : <TrendingDownSymbol />}
      <div>
        <data className="revenue-item-data" value={value}>
          {percentageValue}%
        </data>
        <p className="revenue-item-text">Prev {period}</p>
      </div>
    </li>
  );
}
export default RevenueFigure;
