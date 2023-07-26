﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Materials.MaterialTypes;

namespace Domain.Models.Materials
{
    public class Material
    {
        public MaterialId Id { get; private set; }
        public MaterialName Name { get; private set; }
        public MaterialType Type { get; private set; }
        public TypeAndSize TypeAndSize { get; private set; }
        public Consumption Consumption { get; private set; }
        public Length Length { get; private set; }
        public Weight Weight { get; private set; }

        public Material(MaterialId id,
                        MaterialName name,
                        MaterialType type,
                        TypeAndSize typesize,
                        Consumption consumption,
                        Length length,
                        Weight weight)
        {
            if (id == null) throw new ArgumentException(nameof(MaterialId));
            if (type == null) throw new ArgumentException(nameof(MaterialType));

            this.Id = id;
            this.Type = type;

            if (!Type.ValidateName(name)) throw new ArgumentException(nameof(name));
            if (!Type.ValidateLength(length)) throw new ArgumentException(nameof(Length));
            if (!Type.ValidateWeight(weight)) throw new ArgumentException(nameof(Weight));
            if (!Type.ValidateTypeAndSize(typesize)) throw new ArgumentException(nameof(typesize));
            if (!Type.ValidateConsumption(consumption)) throw new ArgumentException(nameof(consumption));

            this.Name = name;
            this.Length = length;
            this.Weight = weight;
            this.TypeAndSize = typesize;
            this.Consumption = consumption;
        }

        public void ChangeMaterilType(MaterialType materialType)
        {
            if (!materialType.ValidateName(this.Name)
               && !materialType.ValidateLength(this.Length)
               && !materialType.ValidateWeight(this.Weight)
               && !materialType.ValidateTypeAndSize(this.TypeAndSize)
               && !materialType.ValidateConsumption(this.Consumption))
            {
                throw new ArgumentException("値が不正です");
            }

            this.Type = materialType;
        }

        public void ChangeType(ProductType type)
        {
            var value = new TypeAndSize(type, this.TypeAndSize.Size);
            if (!Type.ValidateTypeAndSize(value))
                throw new ArgumentException(nameof(type) + "の値が不正です");

            this.TypeAndSize = value;
        }

        public void ChangeSize(Size size)
        {
            var value = new TypeAndSize(this.TypeAndSize.Type, size);
            if (!Type.ValidateTypeAndSize(value))
                throw new ArgumentException(nameof(size) + "の値が不正です");

            this.TypeAndSize = value;
        }

        public void ChangeConsumption(Consumption consumption)
        {
            if (!Type.ValidateConsumption(consumption))
                throw new ArgumentException(nameof(consumption) + "の値が不正です");

            this.Consumption = consumption;
        }

        public void ChangeName(MaterialName name)
        {
            if (!Type.ValidateName(name))
                throw new ArgumentException(nameof(name) + "の値が不正です");

            this.Name = name;
        }

        public void ChangWeight(Weight weight)
        {
            if (!Type.ValidateWeight(weight))
                throw new ArgumentException(nameof(weight) + "の値が不正です");

            this.Weight = weight;
        }

        public void ChangeLength(Length length)
        {
            if (!Type.ValidateLength(length))
                throw new ArgumentException(nameof(length) + "の値が不正です");

            this.Length = length;
        }
    }
}
