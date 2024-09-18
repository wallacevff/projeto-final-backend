﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

#nullable disable

namespace ProjetoFinalBackend.Infra.EntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ArquivoAtividade", b =>
                {
                    b.Property<Guid>("AnexosId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AtividadeCursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AtividadeTurmaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AtividadeId")
                        .HasColumnType("TEXT");

                    b.HasKey("AnexosId", "AtividadeCursoId", "AtividadeTurmaId", "AtividadeId");

                    b.HasIndex("AtividadeCursoId", "AtividadeTurmaId", "AtividadeId");

                    b.ToTable("ArquivoAtividade");
                });

            modelBuilder.Entity("NavbarItemTipoUsuario", b =>
                {
                    b.Property<Guid>("NavbarId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NavbarId", "TipoUsuarioId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("NavbarItemTipoUsuario");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ConteudoModels.Atividade", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AtividadeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoAtividade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("CursoId", "TurmaId", "AtividadeId");

                    b.ToTable("Atividade", (string)null);

                    b.HasDiscriminator<int>("TipoAtividade");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ConteudoModels.AtividadeAluno", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AtividadeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Concluida")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Nota")
                        .HasColumnType("REAL");

                    b.HasKey("CursoId", "TurmaId", "AtividadeId", "AlunoId");

                    b.HasIndex("AlunoId");

                    b.ToTable("AtividadeAluno", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<int>("Modalidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Curso", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.Turma", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<short>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Tamanho")
                        .HasColumnType("INTEGER");

                    b.HasKey("CursoId", "TurmaId");

                    b.ToTable("Turma", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.TurmaAluno", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("TEXT");

                    b.HasKey("CursoId", "TurmaId", "AlunoId");

                    b.HasIndex("AlunoId");

                    b.ToTable("TurmaAluno", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ForumModels.Forum", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("TEXT");

                    b.HasKey("CursoId", "TurmaId", "ForumId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Forum", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ForumModels.Postagem", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PostagemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemPrincipalCursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemPrincipalForumId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemPrincipalPostagemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemPrincipalTurmaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("TEXT");

                    b.HasKey("CursoId", "TurmaId", "ForumId", "PostagemId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("PostagemPrincipalCursoId", "PostagemPrincipalTurmaId", "PostagemPrincipalForumId", "PostagemPrincipalPostagemId");

                    b.ToTable("Postagem", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Extensao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemCursoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemForumId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostagemTurmaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RepositorioArquivoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoArquivo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostagemCursoId", "PostagemTurmaId", "PostagemForumId", "PostagemId");

                    b.ToTable("Arquivos");

                    b.HasDiscriminator<int>("TipoArquivo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.SistemaModels.NavbarItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Titulo");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NavbarItem", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario", (string)null);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ImagemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoUsuarioCod")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImagemId")
                        .IsUnique();

                    b.HasIndex("TipoUsuarioCod");

                    b.ToTable("Usuario", (string)null);

                    b.HasDiscriminator<int>("TipoUsuarioCod");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ConteudoModels.Materia", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.ConteudoModels.Atividade");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ConteudoModels.Tarefa", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.ConteudoModels.Atividade");

                    b.Property<bool>("Avaliacao")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PrazoDeEntrega")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Documento", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Imagem", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Video", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.Aluno", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.UsuarioModels.Usuario");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.Professor", b =>
                {
                    b.HasBaseType("ProjetoFinalBackend.Domain.UsuarioModels.Usuario");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ArquivoAtividade", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo", null)
                        .WithMany()
                        .HasForeignKey("AnexosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.ConteudoModels.Atividade", null)
                        .WithMany()
                        .HasForeignKey("AtividadeCursoId", "AtividadeTurmaId", "AtividadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NavbarItemTipoUsuario", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.SistemaModels.NavbarItem", null)
                        .WithMany()
                        .HasForeignKey("NavbarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.TipoUsuario", null)
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ConteudoModels.Atividade", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Turma", "Turma")
                        .WithMany("Atividades")
                        .HasForeignKey("CursoId", "TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ConteudoModels.AtividadeAluno", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.ConteudoModels.Atividade", "Atividade")
                        .WithMany()
                        .HasForeignKey("CursoId", "TurmaId", "AtividadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Atividade");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.Curso", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.Professor", "Professor")
                        .WithMany("Cursos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.Turma", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.TurmaAluno", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.Aluno", "Aluno")
                        .WithMany("Turmas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("CursoId", "TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ForumModels.Forum", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.Usuario", "Criador")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Turma", "Turma")
                        .WithMany("Forums")
                        .HasForeignKey("CursoId", "TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criador");

                    b.Navigation("Curso");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ForumModels.Postagem", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.CursoModels.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("CursoId", "TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.ForumModels.Forum", "Forum")
                        .WithMany("Postagens")
                        .HasForeignKey("CursoId", "TurmaId", "ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinalBackend.Domain.ForumModels.Postagem", "PostagemPrincipal")
                        .WithMany("Respostas")
                        .HasForeignKey("PostagemPrincipalCursoId", "PostagemPrincipalTurmaId", "PostagemPrincipalForumId", "PostagemPrincipalPostagemId");

                    b.Navigation("Autor");

                    b.Navigation("Curso");

                    b.Navigation("Forum");

                    b.Navigation("PostagemPrincipal");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.ForumModels.Postagem", null)
                        .WithMany("Arquivos")
                        .HasForeignKey("PostagemCursoId", "PostagemTurmaId", "PostagemForumId", "PostagemId");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.Usuario", b =>
                {
                    b.HasOne("ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels.Arquivo", "Imagem")
                        .WithOne()
                        .HasForeignKey("ProjetoFinalBackend.Domain.UsuarioModels.Usuario", "ImagemId");

                    b.HasOne("ProjetoFinalBackend.Domain.UsuarioModels.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioCod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.CursoModels.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Atividades");

                    b.Navigation("Forums");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ForumModels.Forum", b =>
                {
                    b.Navigation("Postagens");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.ForumModels.Postagem", b =>
                {
                    b.Navigation("Arquivos");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.Aluno", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("ProjetoFinalBackend.Domain.UsuarioModels.Professor", b =>
                {
                    b.Navigation("Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}
