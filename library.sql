PGDMP     +                    {            library    10.15    10.15 	    �
           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            �
           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            �
           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
             postgres    false            �
           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                  postgres    false    4            �            1259    24613    authors    TABLE     w   CREATE TABLE public.authors (
    author_id uuid,
    first_name character varying,
    last_name character varying
);
    DROP TABLE public.authors;
       public         postgres    false    4            �            1259    24596    books    TABLE     �   CREATE TABLE public.books (
    id uuid,
    name character varying,
    author_id uuid,
    description character varying,
    cover bytea
);
    DROP TABLE public.books;
       public         postgres    false    4            �
          0    24613    authors 
   TABLE DATA               C   COPY public.authors (author_id, first_name, last_name) FROM stdin;
    public       postgres    false    198   B       �
          0    24596    books 
   TABLE DATA               H   COPY public.books (id, name, author_id, description, cover) FROM stdin;
    public       postgres    false    197   \       �
   
  x�-�KJCAE�ݫp%����I�o/�ā�gD�� ƈ����zG�RE�^�H�P�`�R`�C��!�`bC/k��[��H���kF���~G}�ӮohO?<��kх �E	)�DTBJ12���P�}E����'FO}ӯi^�x����3��-��-J�PI��M��C;�5�����d~��u�T��ZH`�O��Pb�U9�� �h��}��q����-��g:q!<:�T�L��p�-��Ҍ4��}щ��^�8�3\]r�� � ��      �
   �  x���Kn�1��ߜ�; Fq��%8A7q�( �P�ر��#D�P��
�n��;X4J���9�2gq�\@�!#� �,L�z%������7f��z���Ӫ����?M���p&�8AZ�Pɱw�ȕ��WVw)͈aL��������e�/'��Rz��a�����ݬ��
�y�r.�R�Y.�,4Q���|�����	���c�2�Ww.���o9+aj.���GN�R�bH�2v�z�Eo��Z�����~���)�Ok?����!�uOnu�m�:	��i�0�n��s�>���x��趷��x���(cJ�/Ⰼ�2y�<l����;ː����-Qn������2GB�A7� ��,J�\���R������n�����     