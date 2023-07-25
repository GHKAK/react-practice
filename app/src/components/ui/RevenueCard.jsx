import CardDivider from "./CardDivider";
import RevenueCardButton from "./RevenueCardButton";
import RevenueFigure from "./RevenueFigure";

function RevenueCard({value}){
    return( 
    <div className="card revenue-card">
    <RevenueCardButton />
    <p className="card-title">Revenue</p>
    <data className="card-price" value={value}>
      ${value.toLocaleString('en-US')}
    </data>
    <p className="card-text">Last Week</p>
    <CardDivider />
    <ul className="revenue-list">
      <RevenueFigure period='Week' value = {1.15}/>
      <RevenueFigure period='Month' value = {0.95}/>
    </ul>
  </div>);
}
export default RevenueCard;