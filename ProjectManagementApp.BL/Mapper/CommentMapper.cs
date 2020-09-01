using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Mapper
{
    public class CommentMapper
    {
        public static CommentDetailModel EntityToDetailModel(Comment entity)
        {
            if (entity == null) return null;

            return new CommentDetailModel
            {
                Id = entity.Id,
                Timestamp = entity.Timestamp,
                Text = entity.Text,
                Image = entity.Picture,
                Thread = ThreadMapper.EntityToDetailModel(entity.Thread),
                Author = UserMapper.EntityToDetailModel(entity.Author)
            };
        }

        public static Comment DetailModelToEntity(CommentDetailModel model)
        {
            if (model == null) return null;

            return new Comment
            {
                Id = model.Id,
                Timestamp = model.Timestamp,
                Text = model.Text,
                Picture = model.Image,
                Thread = ThreadMapper.DetailModelToEntity(model.Thread),
                Author = UserMapper.DetailModelToEntity(model.Author)
            };
        }

        public static CommentListModel EntityToListModel(Comment entity)
        {
            return new CommentListModel
            {
                Id = entity.Id,
                Timestamp = entity.Timestamp,
                Author = UserMapper.EntityToListModel(entity.Author)
            };
        }
    }

}
