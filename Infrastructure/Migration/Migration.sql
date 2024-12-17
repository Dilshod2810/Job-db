 
create table users
(
    UserId    serial primary key,
    Fullname  varchar(150),
    Email     varchar(150) unique,
    Phone     varchar(50) unique,
    Role      varchar(20),
    CreatedAt timestamp default current_timestamp
);

create table jobs
(
    jobid       serial primary key,
    employerid  int references users (UserId),
    title       varchar(150),
    description text,
    salary      decimal(10, 2),
    country     varchar(100),
    city        varchar(100),
    status      varchar(20),
    createdat   timestamp default current_timestamp,
    updatedat   timestamp default current_timestamp
);
 
create table applications
(
    applicationid serial primary key,
    jobid         int references jobs (jobid),
    applicantid   int references users (UserId),
    resume        text,
    status        varchar(20),
    createdat     timestamp default current_timestamp,
    updatedat     timestamp default current_timestamp
);

select avg(salary) from jobs ;
select * from applications status="";
select count(applicantid) from jobs where employerid=@id; 