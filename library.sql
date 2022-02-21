--
-- PostgreSQL database dump
--

-- Dumped from database version 10.15
-- Dumped by pg_dump version 10.15

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- Name: uuid-ossp; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;


--
-- Name: EXTENSION "uuid-ossp"; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: authors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.authors (
    author_id uuid,
    first_name character varying,
    last_name character varying
);


ALTER TABLE public.authors OWNER TO postgres;

--
-- Name: books; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.books (
    id uuid,
    name character varying,
    author_id uuid
);


ALTER TABLE public.books OWNER TO postgres;

--
-- Data for Name: authors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.authors (author_id, first_name, last_name) FROM stdin;
10fa3d7a-5c22-486a-97fa-1849fa71e972	Эрнест	Хэммингуей
943ac733-9688-4f91-bc3d-a809201119a9	Александр	Пушкин
fe3eb8cc-df35-4760-8ccb-a142a213355b	Виктор	Пелевин
456cde5a-6f8b-447b-8571-dbaad1e26592	Сергей 	Лукьяненко
\.


--
-- Data for Name: books; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.books (id, name, author_id) FROM stdin;
b7ff3bb0-c031-4361-9b18-f7989cda8bd9	Капитанская дочка	943ac733-9688-4f91-bc3d-a809201119a9
5588f411-3efb-41dd-8e33-322b23d24917	Старик и море	10fa3d7a-5c22-486a-97fa-1849fa71e972
f1b42b12-c232-408b-baaf-acf5d4cabf09	Старик и море1	00000000-0000-0000-0000-000000000000
15c065d5-9e65-4b7d-8c97-328c61d20d51	По ком звонит колокол	10fa3d7a-5c22-486a-97fa-1849fa71e972
dafe280e-ba8d-49fb-af81-79f35f8b913d	Прощай, оружие	10fa3d7a-5c22-486a-97fa-1849fa71e972
ec861552-527f-4eb0-bbbe-136829d03191	Жизнь насекомых	fe3eb8cc-df35-4760-8ccb-a142a213355b
\.


--
-- PostgreSQL database dump complete
--

