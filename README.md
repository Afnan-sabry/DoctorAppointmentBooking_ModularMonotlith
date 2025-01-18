Description
this application for creating a backend system for a doctor appointment booking application. The
system will be designed for a specific single doctor and should handle the logic behind managing
and booking appointments. The project focuses on implementing the necessary APIs and
functionality to meet the business requirements.
-----------------------------------------------------------------------------------------------------
1. Doctor Availability:
  a. As a doctor, I want to be able to list my slots
  b. As a doctor, I want to be able to add new slots where a single time slot should
    have the following:
      i. Id: Guid
      ii. Time: Date → 22/02/2023 04:30 pm
      iii. DoctorId: Guid
      iv. DoctorName: string
      v. IsReserved: bool
      vi. Cost: Decimal
2. Appointment Booking:
  a. As a Patient, I want to be able to view all doctors' available (only) slots
  b. As a Patient, I want to be able to book an appointment on a free slot where. An
Appointment should have the following:
      i. Id: Guid
      ii. SlotId: Guid
      iii. PatientId: Guid
      iv. PatientName: string
      v. ReservedAt: Date
4. Appointment Confirmation:
  a. Once a patient schedules an appointment, the system should send a confirmation
  notification to the patient and the doctor
  b. The confirmation notification should include the appointment details, such as the
  patient's name, appointment time, and Doctor's name.
  c. For the sake of this assessment, the notification could be just a Log message
5. Doctor Appointment Management:
  a. As a Doctor, I want to be able to view my upcoming appointments.
  b. As a Doctor, I want to be able to mark appointments as completed or cancel them
  if necessary.
6. Data Persistence:
a. Shared DB (SQL server)
The system should consist of four modules each with a different architecture as follows:
a. Doctor Availability Module: Traditional Layered Architecture
b. Appointment Booking Module: Clean architecture
c. Appointment Confirmation Module: Simplest architecture possible
d. Doctor Appointment Management: Hexagonal Architecture
---------------------------------------------------------------------------------------------------------------
Communication betwwn modules 
a. Doctor Availability Module: 
b. Appointment Booking Module: 
	Doctor Availability Module:	
	-Book Appointment Slot (Update Is reserved) (async communication  Messaging (RabbitMQ))
	-Get Doctor Availbitly Slots(Direct Call )
	Appointment Confirmation Module
	Send Notification (async communication  Messaging (RabbitMQ))
	
	
c. Appointment Confirmation Module: Simplest architecture possible
d. Doctor Appointment Management: Hexagonal Architecture
	Doctor Availability Module:	
	Get Upcoming Doctor Slots(Direct Call )
	Appointment Booking Module
	Update Status (async communication  Messaging (RabbitMQ))

