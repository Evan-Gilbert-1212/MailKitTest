import React, { useState } from 'react'
import axios from 'axios'

const Home = () => {
  const [emailParams, setEmailParams] = useState({
    Recipient: '',
    EmailAddressTo: '',
    EmailSubject: '',
    EmailBody: '',
  })

  const UpdateEmailParams = e => {
    const fieldName = e.target.name
    const fieldValue = e.target.value

    setEmailParams(prevEmailParams => {
      prevEmailParams[fieldName] = fieldValue
      return prevEmailParams
    })

    console.log(emailParams)
  }

  const sendEmail = () => {
    axios.post('/api/email', emailParams)
  }

  return (
    <section>
      <div className="email-form">
        <div>
          <label>Recipients Name</label>
          <input
            type="text"
            placeholder="Recipients Name"
            name="Recipient"
            onChange={UpdateEmailParams}
          ></input>
        </div>
        <div>
          <label>Recipients Email Address</label>
          <input
            type="text"
            placeholder="Recipients Email Address"
            name="EmailAddressTo"
            onChange={UpdateEmailParams}
          ></input>
        </div>
        <div>
          <label>Subject</label>
          <input
            type="text"
            placeholder="Subject"
            name="EmailSubject"
            onChange={UpdateEmailParams}
          ></input>
        </div>
        <div>
          <label>Email Body</label>
          <textarea
            placeholder="Email Body"
            rows="10"
            cols="30"
            name="EmailBody"
            onChange={UpdateEmailParams}
          ></textarea>
        </div>
      </div>
      <div className="send-email">
        <button onClick={sendEmail}>Send Email</button>
      </div>
    </section>
  )
}

export default Home
