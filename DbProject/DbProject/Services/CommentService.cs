using DbProject.Context;
using DbProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Services
{
    public class CommentService
    {
        private DataContext _context = new DataContext();

        public async Task AddComment()
        {
            var comment = new CommentEntity();

            CaseService caseService = new CaseService();

            CaseEntity CaseAddCommentTo = await caseService.GetCaseById();
            if (CaseAddCommentTo == null) 
            {
                Console.WriteLine("You have enterd an invalid ID...");
                return;
            }

            comment.CaseId = CaseAddCommentTo.Id;

            Console.WriteLine("Comment: ");

            comment.Comment = Console.ReadLine() ?? "";


            await AddCommentToDb(comment);
        }


        public async Task AddCommentToDb(CommentEntity comment)
        {
            _context.Comment.Add(comment);
            var response = await _context.SaveChangesAsync();
        }
    }
}
