# Railway Management API

This repository contains the Railway Management System API, which allows users to check train availability, book seats, and retrieve booking details. Admins can manage trains and seat availability. The project is built using a web server and a relational database.

## Setup Instructions

### Prerequisites
- Ensure you have ASP.NET and SQL SERVER Express installed on your machine.


## Features

- Allows users to check train availability, book seats, and retrieve booking details.
- Admins can manage trains and seat availability.

## Technologies Used

- **Database**: SQL SERVER Express
- **Authentication**: JWT 
- **Host**: Microsoft Azure

## API Endpoints

- `GET /trains` - List all trains, number of seats
- `POST /bookings` - Book a ticket for a passenger
- `GET /bookings/{id}` - Retrieve booking details
- `PUT /bookings/{id}` - Update a booking
- `DELETE /bookings/{id}` - Cancel a booking

## Installation

### Clone the Repository
```bash
git clone https://github.com/Amisha1808/RailwayManagementAPI.git
cd RailwayManagementAPI
