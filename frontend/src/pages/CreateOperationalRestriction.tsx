import { useState } from "react";

export function CreateOperationalRestriction() {
  const [purpose, setPurpose] = useState("");
  const [effectiveDate, setEffectiveDate] = useState("");
  const [effectiveTime, setEffectiveTime] = useState("");
  const [duration, setDuration] = useState("");
  const [situation, setSituation] = useState("");
  const [restriction, setRestriction] = useState("");

  function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const operationalRestriction = {
      purpose,
      effectiveDate,
      effectiveTime,
      duration,
      situation,
      restriction,
    };

    console.log(operationalRestriction);
  }

  return (
    <div>
      <h1>Create Operational Restriction</h1>

      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="purpose">Purpose</label>
          <input
            id="purpose"
            type="text"
            value={purpose}
            onChange={(event) => setPurpose(event.target.value)}
          />
        </div>

        <div>
          <label>Effective from</label>
          <input
            type="date"
            value={effectiveDate}
            onChange={(event) => setEffectiveDate(event.target.value)}
          />
          <input
            type="time"
            value={effectiveTime}
            onChange={(event) => setEffectiveTime(event.target.value)}
          />
        </div>

        <div>
          <label htmlFor="duration">Duration</label>
          <input
            id="duration"
            type="text"
            value={duration}
            onChange={(event) => setDuration(event.target.value)}
          />
        </div>

        <div>
          <label htmlFor="situation">About the situation</label>
          <p>Explain why the Operational Restriction is required.</p>
          <textarea
            id="situation"
            value={situation}
            onChange={(event) => setSituation(event.target.value)}
          />
        </div>

        <div>
          <label htmlFor="restriction">
            About the Operational Restriction
          </label>
          <p>
            Describe the Operational Restriction and what is required to
            enforce it.
          </p>
          <textarea
            id="restriction"
            value={restriction}
            onChange={(event) => setRestriction(event.target.value)}
          />
        </div>

        <button type="submit">Create Operational Restriction</button>
      </form>
    </div>
  );
}