USE Health_Insurance

INSERT INTO city values ('Jurm')
INSERT INTO city values ('Houston')
INSERT INTO city values ('Austin')
INSERT INTO city values ('Chicago')
INSERT INTO city values ('Edison')
INSERT INTO city values ('Dallas')
INSERT INTO city values ('New York')
INSERT INTO city values ('Buffalo')
INSERT INTO city values ('Rochester')
INSERT INTO city values ('Los Angeles')
INSERT INTO city values ('San Diego')
INSERT INTO city values ('San Francisco')
INSERT INTO city values ('Oakland')
INSERT INTO city values ('Newark')
INSERT INTO city values ('Fairbanks')

insert into state values ('California');
insert into state values ('Texas');
insert into state values ('New Jersey');
insert into state values ('Alaska');
insert into state values ('New York');
insert into state values ('Illinois');

insert into dbo.credentials values (0);
insert into dbo.credentials values (1);
insert into dbo.credentials values (2);
insert into dbo.credentials values (3);
insert into dbo.credentials values (4);

insert into dbo.users values ('Chris','1234',1);
insert into dbo.users values ('Anthony','1234',1);
insert into dbo.users values ('John','1234',1);
insert into dbo.users values ('Gabriel','1234',1);

insert into dbo.Users values ('Agent','1234',2);
insert into hospital values ('AusCare','1901 Crossing Place',3,2,'78741','7372478179');
insert into hospital values ('JFK Medical Center','65 James St',5,3,'08820','7323217000');
insert into hospital values ('Manhattan Eye Ear and Throat Hospital','210 E 64th St',7,5,'10021','2128389200');

insert into doctor values ('James','Bond',0,'01/01/1953 23:59:59.999', '1112223333', 'JAMESBOND@gmail.com', '1112223333','1902 Crossing Place',3,2,'78750', 'Medical',1);
insert into doctor values ('Justin','Biber',0,'01/01/2000 23:59:59.999', '1112224444', 'justinbiber@gmail.com', '1112223334','64 James St',5,3,'08819', 'Dental',2);
insert into doctor values ('Taylor','Swift',1,'01/01/1986 23:59:59.999', '2112223333', 'taylorswift@gmail.com', '4112223333', '63 James St',5,3,'08819','Dental',2);
insert into doctor values ('Britney','Spears',1,'01/01/1980 22:57:59.999', '3112223333', 'britneyspears@gmail.com', '5112223333', '62 James St',5,3,'08820','Eye',2);
insert into doctor values ('Scarlett','Johansson',1,'01/01/1985 01:01:52.000', '4112223333', 'scarlettpretty@gmail.com', '6112223333', '21 E 63th St',7,5,'10021','Medical',3);
insert into doctor values ('Nicolas','Cage',0,'01/01/1960 23:59:59.999', '5112223333', 'Nico@hotmail.com', '7112223333','29 E 68th St',7,5,'10030', 'Medical',null);

insert into customer values (1,'Chris','Ge',0,'06/11/1993 08:00:0.000','73 Winthrop Road',5,3,'08817','5126291224', 'xiangchenge@gmail.com', '384494201',null);
insert into customer values (2,'Anthony','Houston',0,'06/11/1993 08:00:0.000','73 Winthrop Road',5,3,'08817','5126281224', 'tonylam1216@gmail.com', '384484201',null);
insert into customer values (3,'John','Cao',0,'06/11/1993 08:00:0.000','73 Winthrop Road',5,3,'08817','5126271224', 'john_cao@hotmail.com', '384474201',null);
insert into customer values (4,'Gabriel','Munoz',0,'06/11/1993 08:00:0.000','73 Winthrop Road',5,3,'08817','5126261224', 'latin_eston007@hotmail.com', '384464201',null);


insert into agent values (5,'Calvin','Klein',0,'06/11/1993 08:00:0.000','71 Winthrop Road',5,3,'08817','5126261220', 'kalvin@hotmail.com', '364464201');

insert into quote values ('First Quote By Chris', 1, 'This Quote is created by mistake', null, null, null,null, 0);

insert into claims values ('In Progress', 1, 1,'This Quote is created by mistake', '12/03/2017 08:00:0.000', null, null);

insert into plantype values('Medical Care', 'International Health and Wellbeing',
'International Health and Wellbeing provides cover for screenings, tests, examinations and counselling support for a range of life crises and tailored advice and support through our online health education and health risk assessment, helping you to take control and manage your health the way you want.',72);

insert into plantype values('Vision and Dental', null, 'International Vision and Dental pays for the beneficiary’s routine eye examination and pays costs for spectacles and lenses. It also covers a wide range of preventative, routine and major dental treatments',67.98);

insert into plantype values('Medical Evacuation', 'International Medical Evacuation',
'International Medical Evacuation provides coverage for reasonable transportation costs to the nearest centre of medical excellence in the event that the treatment is not available locally in an emergency. This option also includes repatriation coverage, allowing the benefi ciary to return to their country of habitual residence or country of nationality to be treated in a familiar location. It also includes compassionate visits for a parent, spouse, partner, sibling, or child to visit a beneficiary after an accident or sudden illness and the beneficiary has not been evacuated or repatriated.'
, 72.95);


