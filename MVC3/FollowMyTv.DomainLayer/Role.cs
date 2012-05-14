using System.Collections.Generic;

namespace FollowMyTv.DomainLayer
{
    public class Role
    {
        public static Role Administrator = new Role(FollowMyTvRoles.ADMINISTRATOR);
        public static Role AuthUser      = new Role(FollowMyTvRoles.AUTH_USER);

        private readonly string _name;

        private Role( string name )
        {
            _name = name;
        }

        public new string ToString()
        {
            return _name;
        }

        private static readonly Role[] RolesOrdered = new []{Administrator, AuthUser};

        public static string[] GetContainedRoles(Role role)
        {
            List<string> roles = new List<string>();
            bool control = false;
            foreach (Role r in RolesOrdered)
            {
                if( control )
                {
                    roles.Add(r._name);
                }
                else
                {
                    if ( r.Equals( role ) )
                    {
                        roles.Add(r._name);
                        control = true;
                    }                    
                }
            }

            return roles.ToArray();
        }

        /*
         * Equality Pattern
         */
        public override bool Equals( object obj )
        {
            Role role = obj as Role;
            return Equals(role);
        }

        public bool Equals(Role other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._name, _name);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }
    }
}