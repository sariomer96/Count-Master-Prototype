namespace Colony
{
    public class EnemyUnitController : CharacterUnit
    {
 
        private void OnEnable()
        {
        
            destination = transform.parent;

            _colony = transform.GetComponentInParent<Colony>();

            if (_colony)
                _colony.AddUnit(this);
        
        }
    
        private void OnDisable()
        { 
            if (_colony)
                _colony.RemoveUnit(this);
        
        }
    }
}
