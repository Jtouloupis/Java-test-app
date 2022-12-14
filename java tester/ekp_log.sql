PGDMP                         z           JavaEssentials    14.3    14.3                 0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16558    JavaEssentials    DATABASE     t   CREATE DATABASE "JavaEssentials" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1253';
     DROP DATABASE "JavaEssentials";
                postgres    false                       0    0    DATABASE "JavaEssentials"    COMMENT     J   COMMENT ON DATABASE "JavaEssentials" IS 'Ekpaideytiko Logismiko Ergasia';
                   postgres    false    3331            ?            1255    16598    page_increment()    FUNCTION     7  CREATE FUNCTION public.page_increment() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
declare 
	v_page_inc int := 0;
begin
	Select max(page) + 1 into v_page_inc from lessons where chapter = NEW.chapter;
	if v_page_inc is null then
		new.page := 1;
	else
		new.page := v_page_inc;
	end if;
return new;
end;
$$;
 '   DROP FUNCTION public.page_increment();
       public          postgres    false            ?            1259    16593    account_lesson    TABLE     ?   CREATE TABLE public.account_lesson (
    accountid integer,
    chapterid integer,
    lessonid integer,
    finished boolean DEFAULT false
);
 "   DROP TABLE public.account_lesson;
       public         heap    postgres    false            ?            1259    16567    accounts    TABLE     ?   CREATE TABLE public.accounts (
    id integer NOT NULL,
    firstname character varying(50),
    lastname character varying(50),
    username character varying(50),
    password character varying(50)
);
    DROP TABLE public.accounts;
       public         heap    postgres    false            ?            1259    16566    accounts_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.accounts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.accounts_id_seq;
       public          postgres    false    210                       0    0    accounts_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.accounts_id_seq OWNED BY public.accounts.id;
          public          postgres    false    209            ?            1259    16585    lessons    TABLE     ?   CREATE TABLE public.lessons (
    id integer NOT NULL,
    chapter integer,
    code text,
    explanation text,
    result text,
    page integer
);
    DROP TABLE public.lessons;
       public         heap    postgres    false            ?            1259    16584    lessons_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.lessons_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.lessons_id_seq;
       public          postgres    false    212                       0    0    lessons_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.lessons_id_seq OWNED BY public.lessons.id;
          public          postgres    false    211            f           2604    16570    accounts id    DEFAULT     j   ALTER TABLE ONLY public.accounts ALTER COLUMN id SET DEFAULT nextval('public.accounts_id_seq'::regclass);
 :   ALTER TABLE public.accounts ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    210    209    210            g           2604    16588 
   lessons id    DEFAULT     h   ALTER TABLE ONLY public.lessons ALTER COLUMN id SET DEFAULT nextval('public.lessons_id_seq'::regclass);
 9   ALTER TABLE public.lessons ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    212    211    212            ?          0    16593    account_lesson 
   TABLE DATA           R   COPY public.account_lesson (accountid, chapterid, lessonid, finished) FROM stdin;
    public          postgres    false    213   ?       ?          0    16567    accounts 
   TABLE DATA           O   COPY public.accounts (id, firstname, lastname, username, password) FROM stdin;
    public          postgres    false    210   ?       ?          0    16585    lessons 
   TABLE DATA           O   COPY public.lessons (id, chapter, code, explanation, result, page) FROM stdin;
    public          postgres    false    212   ?                  0    0    accounts_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.accounts_id_seq', 2, true);
          public          postgres    false    209                       0    0    lessons_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.lessons_id_seq', 15, true);
          public          postgres    false    211            j           2606    16572    accounts accounts_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.accounts
    ADD CONSTRAINT accounts_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.accounts DROP CONSTRAINT accounts_pkey;
       public            postgres    false    210            l           2606    16592    lessons lessons_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.lessons
    ADD CONSTRAINT lessons_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.lessons DROP CONSTRAINT lessons_pkey;
       public            postgres    false    212            m           2620    16599    lessons trg_page_increment    TRIGGER     y   CREATE TRIGGER trg_page_increment BEFORE INSERT ON public.lessons FOR EACH ROW EXECUTE FUNCTION public.page_increment();
 3   DROP TRIGGER trg_page_increment ON public.lessons;
       public          postgres    false    212    214            ?      x?3?4?4?,?????? ??      ?      x?3?L?@.#?*?????? AL?      ?   Q   x?34?4?L??"0UřZ^?i?ehO)N?ɋ)R) ??,?31?ӈ?Дӈ3%?? D%Wp&$???M????? q??     