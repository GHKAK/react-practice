import Contact from "./Contact";

function ContactList(){
    return(<ul className="contact-list">
    <li>
      <Contact type={"mail"} contact={"xyz@mail.com"} />
    </li>
    <li>
      <Contact type={"tel"} contact={"+00 123-456-789"} />
    </li>
  </ul>);
}
export default ContactList;