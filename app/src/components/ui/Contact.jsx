function Contact({type, contact}) {
const link = type === 'mail' ? `mailto:${contact}` : `tel:+${contact}`;
  return (
    <a href={link} className="contact-link icon-box">
      <span className="material-symbols-rounded  icon">{type ==='mail'?'mail':'call'}</span>
      <p className="text">{contact}</p>
    </a>
  );
}
export default Contact;
