using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

/* Generated from ec */

namespace SideWinder_Batch.Classes
{
    public class SWEC
    {
        #region Members

        private int _id;
        private string _tpa_id;
        private string _employer_id;
        private string _plan_id;
        private string _employee_id;
        private string _employee_account_id;
        private string _coverage_id;
        private string _account_type_code;
        private DateTime _plan_start_date;
        private DateTime _plan_end_date;
        private string _account_status;
        private decimal _annual_prefunded_annual_election_amt;
        private decimal _employee_pay_period_election;
        private decimal _employer_pay_period_election;
        private string _account_number;
        private string _card_number;
        private decimal _available_balance;
        private decimal _disbursable_balance;
        private decimal _employee_contribution_YTD;
        private decimal _employer_contribution_YTD;
        private string _employee_key;
        private DateTime _last_updated;
        private DateTime _last_updated_time;
        private decimal _preauth_hold_balance;
        private string _employee_last_name;
        private string _employee_first_name;
        private string _employee_middle_initial;
        private string _employee_address_1;
        private string _employee_address_2;
        private string _employee_city;
        private string _employee_state;
        private string _employee_zip;
        private string _country_code;
        private string _employee_phone;
        private string _employee_email_address;
        private DateTime _employee_birth_date;
        private string _employee_gender;
        private string _product_partner_account_status;
        private DateTime _product_partner_next_interest_payment_date;
        private decimal _interest_accrued_amount;
        private string _employee_status;
        private string _employee_social_security_number;
        private decimal _family_singlefund_avail_balance;
        private decimal _family_singlefund_preauth_balance;
        private decimal _family_singlefund_disbursable_balance;
        private string _dependent_id;
        private DateTime _effective_date;
        private DateTime _termination_date;
        private decimal _individual_rollover_avail_balance;
        private decimal _individual_rollover_disb_balance;
        private decimal _individual_rollover_preauthhold_balance;
        private decimal _family_singlefund_rollover_amt;
        private decimal _individual_rollover_disb_PTD;
        private decimal _family_singlefund_rollover_disb_balance;
        private decimal _family_singlefund_rollover_disb_PTD;
        private decimal _family_singlefund_rollover_preauth_balance;
        private decimal _individual_rollover_amount;
        private decimal _family_singlefund_rollover_avail_balance;
        private decimal _individual_amount;
        private string _esignature_flag;
        private DateTime _esignature_date;
        private decimal _balance_due;
        private DateTime _coverage_start_date;
        private DateTime _coverage_end_date;
        private string _life_event_type;
        private string _coverage_period_status;
        private decimal _coverage_annual_election;
        private decimal _coverage_available_balance;
        private decimal _coverage_disbursable_balance;
        private decimal _coverage_disbursements_PTD;
        private decimal _coverage_preauth_balance;
        private decimal _balance_max;
        private decimal _other_deposits;
        private decimal _family_other_deposits;
        private string _coverage_tier_id;
        private decimal _individual_balance_max;
        private string _fund_rollover_status_code;
        private string _family_fund_rollover_status_code;
        private string _fund_rollover_error_code;
        private string _family_fund_rollover_error_code;
        private decimal _rollover_deposits;
        private decimal _family_rollover_deposits;
        private DateTime _start_autodeposit_date;
        private DateTime _start_fixed_employer_funding_date;
        private string _autodeposit_calendar_id;
        private decimal _deductible_PTD;
        private decimal _bypass_deductible_PTD;
        private decimal _current_annual_election;
        private string _enrollment_method;
        private string _employer_broker_id;
        private string _claims_crossover_optin;

        #endregion Members

        #region Properties

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string tpa_id
        {
            get
            {
                return _tpa_id;
            }
            set
            {
                _tpa_id = value;
            }
        }

        public string employer_id
        {
            get
            {
                return _employer_id;
            }
            set
            {
                _employer_id = value;
            }
        }

        public string plan_id
        {
            get
            {
                return _plan_id;
            }
            set
            {
                _plan_id = value;
            }
        }

        public string employee_id
        {
            get
            {
                return _employee_id;
            }
            set
            {
                _employee_id = value;
            }
        }

        public string employee_account_id
        {
            get
            {
                return _employee_account_id;
            }
            set
            {
                _employee_account_id = value;
            }
        }

        public string coverage_id
        {
            get
            {
                return _coverage_id;
            }
            set
            {
                _coverage_id = value;
            }
        }

        public string account_type_code
        {
            get
            {
                return _account_type_code;
            }
            set
            {
                _account_type_code = value;
            }
        }

        public DateTime plan_start_date
        {
            get
            {
                return _plan_start_date;
            }
            set
            {
                _plan_start_date = value;
            }
        }

        public DateTime plan_end_date
        {
            get
            {
                return _plan_end_date;
            }
            set
            {
                _plan_end_date = value;
            }
        }

        public string account_status
        {
            get
            {
                return _account_status;
            }
            set
            {
                _account_status = value;
            }
        }

        public decimal annual_prefunded_annual_election_amt
        {
            get
            {
                return _annual_prefunded_annual_election_amt;
            }
            set
            {
                _annual_prefunded_annual_election_amt = value;
            }
        }

        public decimal employee_pay_period_election
        {
            get
            {
                return _employee_pay_period_election;
            }
            set
            {
                _employee_pay_period_election = value;
            }
        }

        public decimal employer_pay_period_election
        {
            get
            {
                return _employer_pay_period_election;
            }
            set
            {
                _employer_pay_period_election = value;
            }
        }

        public string account_number
        {
            get
            {
                return _account_number;
            }
            set
            {
                _account_number = value;
            }
        }

        public string card_number
        {
            get
            {
                return _card_number;
            }
            set
            {
                _card_number = value;
            }
        }

        public decimal available_balance
        {
            get
            {
                return _available_balance;
            }
            set
            {
                _available_balance = value;
            }
        }

        public decimal disbursable_balance
        {
            get
            {
                return _disbursable_balance;
            }
            set
            {
                _disbursable_balance = value;
            }
        }

        public decimal employee_contribution_YTD
        {
            get
            {
                return _employee_contribution_YTD;
            }
            set
            {
                _employee_contribution_YTD = value;
            }
        }

        public decimal employer_contribution_YTD
        {
            get
            {
                return _employer_contribution_YTD;
            }
            set
            {
                _employer_contribution_YTD = value;
            }
        }

        public string employee_key
        {
            get
            {
                return _employee_key;
            }
            set
            {
                _employee_key = value;
            }
        }

        public DateTime last_updated
        {
            get
            {
                return _last_updated;
            }
            set
            {
                _last_updated = value;
            }
        }

        public DateTime last_updated_time
        {
            get
            {
                return _last_updated_time;
            }
            set
            {
                _last_updated_time = value;
            }
        }

        public decimal preauth_hold_balance
        {
            get
            {
                return _preauth_hold_balance;
            }
            set
            {
                _preauth_hold_balance = value;
            }
        }

        public string employee_last_name
        {
            get
            {
                return _employee_last_name;
            }
            set
            {
                _employee_last_name = value;
            }
        }

        public string employee_first_name
        {
            get
            {
                return _employee_first_name;
            }
            set
            {
                _employee_first_name = value;
            }
        }

        public string employee_middle_initial
        {
            get
            {
                return _employee_middle_initial;
            }
            set
            {
                _employee_middle_initial = value;
            }
        }

        public string employee_address_1
        {
            get
            {
                return _employee_address_1;
            }
            set
            {
                _employee_address_1 = value;
            }
        }

        public string employee_address_2
        {
            get
            {
                return _employee_address_2;
            }
            set
            {
                _employee_address_2 = value;
            }
        }

        public string employee_city
        {
            get
            {
                return _employee_city;
            }
            set
            {
                _employee_city = value;
            }
        }

        public string employee_state
        {
            get
            {
                return _employee_state;
            }
            set
            {
                _employee_state = value;
            }
        }

        public string employee_zip
        {
            get
            {
                return _employee_zip;
            }
            set
            {
                _employee_zip = value;
            }
        }

        public string country_code
        {
            get
            {
                return _country_code;
            }
            set
            {
                _country_code = value;
            }
        }

        public string employee_phone
        {
            get
            {
                return _employee_phone;
            }
            set
            {
                _employee_phone = value;
            }
        }

        public string employee_email_address
        {
            get
            {
                return _employee_email_address;
            }
            set
            {
                _employee_email_address = value;
            }
        }

        public DateTime employee_birth_date
        {
            get
            {
                return _employee_birth_date;
            }
            set
            {
                _employee_birth_date = value;
            }
        }

        public string employee_gender
        {
            get
            {
                return _employee_gender;
            }
            set
            {
                _employee_gender = value;
            }
        }

        public string product_partner_account_status
        {
            get
            {
                return _product_partner_account_status;
            }
            set
            {
                _product_partner_account_status = value;
            }
        }

        public DateTime product_partner_next_interest_payment_date
        {
            get
            {
                return _product_partner_next_interest_payment_date;
            }
            set
            {
                _product_partner_next_interest_payment_date = value;
            }
        }

        public decimal interest_accrued_amount
        {
            get
            {
                return _interest_accrued_amount;
            }
            set
            {
                _interest_accrued_amount = value;
            }
        }

        public string employee_status
        {
            get
            {
                return _employee_status;
            }
            set
            {
                _employee_status = value;
            }
        }

        public string employee_social_security_number
        {
            get
            {
                return _employee_social_security_number;
            }
            set
            {
                _employee_social_security_number = value;
            }
        }

        public decimal family_singlefund_avail_balance
        {
            get
            {
                return _family_singlefund_avail_balance;
            }
            set
            {
                _family_singlefund_avail_balance = value;
            }
        }

        public decimal family_singlefund_preauth_balance
        {
            get
            {
                return _family_singlefund_preauth_balance;
            }
            set
            {
                _family_singlefund_preauth_balance = value;
            }
        }

        public decimal family_singlefund_disbursable_balance
        {
            get
            {
                return _family_singlefund_disbursable_balance;
            }
            set
            {
                _family_singlefund_disbursable_balance = value;
            }
        }

        public string dependent_id
        {
            get
            {
                return _dependent_id;
            }
            set
            {
                _dependent_id = value;
            }
        }

        public DateTime effective_date
        {
            get
            {
                return _effective_date;
            }
            set
            {
                _effective_date = value;
            }
        }

        public DateTime termination_date
        {
            get
            {
                return _termination_date;
            }
            set
            {
                _termination_date = value;
            }
        }

        public decimal individual_rollover_avail_balance
        {
            get
            {
                return _individual_rollover_avail_balance;
            }
            set
            {
                _individual_rollover_avail_balance = value;
            }
        }

        public decimal individual_rollover_disb_balance
        {
            get
            {
                return _individual_rollover_disb_balance;
            }
            set
            {
                _individual_rollover_disb_balance = value;
            }
        }

        public decimal individual_rollover_preauthhold_balance
        {
            get
            {
                return _individual_rollover_preauthhold_balance;
            }
            set
            {
                _individual_rollover_preauthhold_balance = value;
            }
        }

        public decimal family_singlefund_rollover_amt
        {
            get
            {
                return _family_singlefund_rollover_amt;
            }
            set
            {
                _family_singlefund_rollover_amt = value;
            }
        }

        public decimal individual_rollover_disb_PTD
        {
            get
            {
                return _individual_rollover_disb_PTD;
            }
            set
            {
                _individual_rollover_disb_PTD = value;
            }
        }

        public decimal family_singlefund_rollover_disb_balance
        {
            get
            {
                return _family_singlefund_rollover_disb_balance;
            }
            set
            {
                _family_singlefund_rollover_disb_balance = value;
            }
        }

        public decimal family_singlefund_rollover_disb_PTD
        {
            get
            {
                return _family_singlefund_rollover_disb_PTD;
            }
            set
            {
                _family_singlefund_rollover_disb_PTD = value;
            }
        }

        public decimal family_singlefund_rollover_preauth_balance
        {
            get
            {
                return _family_singlefund_rollover_preauth_balance;
            }
            set
            {
                _family_singlefund_rollover_preauth_balance = value;
            }
        }

        public decimal individual_rollover_amount
        {
            get
            {
                return _individual_rollover_amount;
            }
            set
            {
                _individual_rollover_amount = value;
            }
        }

        public decimal family_singlefund_rollover_avail_balance
        {
            get
            {
                return _family_singlefund_rollover_avail_balance;
            }
            set
            {
                _family_singlefund_rollover_avail_balance = value;
            }
        }

        public decimal individual_amount
        {
            get
            {
                return _individual_amount;
            }
            set
            {
                _individual_amount = value;
            }
        }

        public string esignature_flag
        {
            get
            {
                return _esignature_flag;
            }
            set
            {
                _esignature_flag = value;
            }
        }

        public DateTime esignature_date
        {
            get
            {
                return _esignature_date;
            }
            set
            {
                _esignature_date = value;
            }
        }

        public decimal balance_due
        {
            get
            {
                return _balance_due;
            }
            set
            {
                _balance_due = value;
            }
        }

        public DateTime coverage_start_date
        {
            get
            {
                return _coverage_start_date;
            }
            set
            {
                _coverage_start_date = value;
            }
        }

        public DateTime coverage_end_date
        {
            get
            {
                return _coverage_end_date;
            }
            set
            {
                _coverage_end_date = value;
            }
        }

        public string life_event_type
        {
            get
            {
                return _life_event_type;
            }
            set
            {
                _life_event_type = value;
            }
        }

        public string coverage_period_status
        {
            get
            {
                return _coverage_period_status;
            }
            set
            {
                _coverage_period_status = value;
            }
        }

        public decimal coverage_annual_election
        {
            get
            {
                return _coverage_annual_election;
            }
            set
            {
                _coverage_annual_election = value;
            }
        }

        public decimal coverage_available_balance
        {
            get
            {
                return _coverage_available_balance;
            }
            set
            {
                _coverage_available_balance = value;
            }
        }

        public decimal coverage_disbursable_balance
        {
            get
            {
                return _coverage_disbursable_balance;
            }
            set
            {
                _coverage_disbursable_balance = value;
            }
        }

        public decimal coverage_disbursements_PTD
        {
            get
            {
                return _coverage_disbursements_PTD;
            }
            set
            {
                _coverage_disbursements_PTD = value;
            }
        }

        public decimal coverage_preauth_balance
        {
            get
            {
                return _coverage_preauth_balance;
            }
            set
            {
                _coverage_preauth_balance = value;
            }
        }

        public decimal balance_max
        {
            get
            {
                return _balance_max;
            }
            set
            {
                _balance_max = value;
            }
        }

        public decimal other_deposits
        {
            get
            {
                return _other_deposits;
            }
            set
            {
                _other_deposits = value;
            }
        }

        public decimal family_other_deposits
        {
            get
            {
                return _family_other_deposits;
            }
            set
            {
                _family_other_deposits = value;
            }
        }

        public string coverage_tier_id
        {
            get
            {
                return _coverage_tier_id;
            }
            set
            {
                _coverage_tier_id = value;
            }
        }

        public decimal individual_balance_max
        {
            get
            {
                return _individual_balance_max;
            }
            set
            {
                _individual_balance_max = value;
            }
        }

        public string fund_rollover_status_code
        {
            get
            {
                return _fund_rollover_status_code;
            }
            set
            {
                _fund_rollover_status_code = value;
            }
        }

        public string family_fund_rollover_status_code
        {
            get
            {
                return _family_fund_rollover_status_code;
            }
            set
            {
                _family_fund_rollover_status_code = value;
            }
        }

        public string fund_rollover_error_code
        {
            get
            {
                return _fund_rollover_error_code;
            }
            set
            {
                _fund_rollover_error_code = value;
            }
        }

        public string family_fund_rollover_error_code
        {
            get
            {
                return _family_fund_rollover_error_code;
            }
            set
            {
                _family_fund_rollover_error_code = value;
            }
        }

        public decimal rollover_deposits
        {
            get
            {
                return _rollover_deposits;
            }
            set
            {
                _rollover_deposits = value;
            }
        }

        public decimal family_rollover_deposits
        {
            get
            {
                return _family_rollover_deposits;
            }
            set
            {
                _family_rollover_deposits = value;
            }
        }

        public DateTime start_autodeposit_date
        {
            get
            {
                return _start_autodeposit_date;
            }
            set
            {
                _start_autodeposit_date = value;
            }
        }

        public DateTime start_fixed_employer_funding_date
        {
            get
            {
                return _start_fixed_employer_funding_date;
            }
            set
            {
                _start_fixed_employer_funding_date = value;
            }
        }

        public string autodeposit_calendar_id
        {
            get
            {
                return _autodeposit_calendar_id;
            }
            set
            {
                _autodeposit_calendar_id = value;
            }
        }

        public decimal deductible_PTD
        {
            get
            {
                return _deductible_PTD;
            }
            set
            {
                _deductible_PTD = value;
            }
        }

        public decimal bypass_deductible_PTD
        {
            get
            {
                return _bypass_deductible_PTD;
            }
            set
            {
                _bypass_deductible_PTD = value;
            }
        }

        public decimal current_annual_election
        {
            get
            {
                return _current_annual_election;
            }
            set
            {
                _current_annual_election = value;
            }
        }

        public string enrollment_method
        {
            get
            {
                return _enrollment_method;
            }
            set
            {
                _enrollment_method = value;
            }
        }

        public string employer_broker_id
        {
            get
            {
                return _employer_broker_id;
            }
            set
            {
                _employer_broker_id = value;
            }
        }

        public string claims_crossover_optin
        {
            get
            {
                return _claims_crossover_optin;
            }
            set
            {
                _claims_crossover_optin = value;
            }
        }

        #endregion Properties

        #region Class LifeCycle

        public SWEC(
			int id
            ,string ptpa_id
            ,string pemployer_id
            ,string pplan_id
            ,string pemployee_id
            ,string pemployee_account_id
            ,string pcoverage_id
            ,string paccount_type_code
            ,DateTime pplan_start_date
            ,DateTime pplan_end_date
            ,string paccount_status
            ,decimal pannual_prefunded_annual_election_amt
            ,decimal pemployee_pay_period_election
            ,decimal pemployer_pay_period_election
            ,string paccount_number
            ,string pcard_number
            ,decimal pavailable_balance
            ,decimal pdisbursable_balance
            ,decimal pemployee_contribution_YTD
            ,decimal pemployer_contribution_YTD
            ,string pemployee_key
            ,DateTime plast_updated
            ,DateTime plast_updated_time
            ,decimal ppreauth_hold_balance
            ,string pemployee_last_name
            ,string pemployee_first_name
            ,string pemployee_middle_initial
            ,string pemployee_address_1
            ,string pemployee_address_2
            ,string pemployee_city
            ,string pemployee_state
            ,string pemployee_zip
            ,string pcountry_code
            ,string pemployee_phone
            ,string pemployee_email_address
            ,DateTime pemployee_birth_date
            ,string pemployee_gender
            ,string pproduct_partner_account_status
            ,DateTime pproduct_partner_next_interest_payment_date
            ,decimal pinterest_accrued_amount
            ,string pemployee_status
            ,string pemployee_social_security_number
            ,decimal pfamily_singlefund_avail_balance
            ,decimal pfamily_singlefund_preauth_balance
            ,decimal pfamily_singlefund_disbursable_balance
            ,string pdependent_id
            ,DateTime peffective_date
            ,DateTime ptermination_date
            ,decimal pindividual_rollover_avail_balance
            ,decimal pindividual_rollover_disb_balance
            ,decimal pindividual_rollover_preauthhold_balance
            ,decimal pfamily_singlefund_rollover_amt
            ,decimal pindividual_rollover_disb_PTD
            ,decimal pfamily_singlefund_rollover_disb_balance
            ,decimal pfamily_singlefund_rollover_disb_PTD
            ,decimal pfamily_singlefund_rollover_preauth_balance
            ,decimal pindividual_rollover_amount
            ,decimal pfamily_singlefund_rollover_avail_balance
            ,decimal pindividual_amount
            ,string pesignature_flag
            ,DateTime pesignature_date
            ,decimal pbalance_due
            ,DateTime pcoverage_start_date
            ,DateTime pcoverage_end_date
            ,string plife_event_type
            ,string pcoverage_period_status
            ,decimal pcoverage_annual_election
            ,decimal pcoverage_available_balance
            ,decimal pcoverage_disbursable_balance
            ,decimal pcoverage_disbursements_PTD
            ,decimal pcoverage_preauth_balance
            ,decimal pbalance_max
            ,decimal pother_deposits
            ,decimal pfamily_other_deposits
            ,string pcoverage_tier_id
            ,decimal pindividual_balance_max
            ,string pfund_rollover_status_code
            ,string pfamily_fund_rollover_status_code
            ,string pfund_rollover_error_code
            ,string pfamily_fund_rollover_error_code
            ,decimal prollover_deposits
            ,decimal pfamily_rollover_deposits
            ,DateTime pstart_autodeposit_date
            ,DateTime pstart_fixed_employer_funding_date
            ,string pautodeposit_calendar_id
            ,decimal pdeductible_PTD
            ,decimal pbypass_deductible_PTD
            ,decimal pcurrent_annual_election
            ,string penrollment_method
            ,string pemployer_broker_id
            ,string pclaims_crossover_optin
			)
        {
            tpa_id = ptpa_id;
            employer_id = pemployer_id;
            plan_id = pplan_id;
            employee_id = pemployee_id;
            employee_account_id = pemployee_account_id;
            coverage_id = pcoverage_id;
            account_type_code = paccount_type_code;
            plan_start_date = pplan_start_date;
            plan_end_date = pplan_end_date;
            account_status = paccount_status;
            annual_prefunded_annual_election_amt = pannual_prefunded_annual_election_amt;
            employee_pay_period_election = pemployee_pay_period_election;
            employer_pay_period_election = pemployer_pay_period_election;
            account_number = paccount_number;
            card_number = pcard_number;
            available_balance = pavailable_balance;
            disbursable_balance = pdisbursable_balance;
            employee_contribution_YTD = pemployee_contribution_YTD;
            employer_contribution_YTD = pemployer_contribution_YTD;
            employee_key = pemployee_key;
            last_updated = plast_updated;
            last_updated_time = plast_updated_time;
            preauth_hold_balance = ppreauth_hold_balance;
            employee_last_name = pemployee_last_name;
            employee_first_name = pemployee_first_name;
            employee_middle_initial = pemployee_middle_initial;
            employee_address_1 = pemployee_address_1;
            employee_address_2 = pemployee_address_2;
            employee_city = pemployee_city;
            employee_state = pemployee_state;
            employee_zip = pemployee_zip;
            country_code = pcountry_code;
            employee_phone = pemployee_phone;
            employee_email_address = pemployee_email_address;
            employee_birth_date = pemployee_birth_date;
            employee_gender = pemployee_gender;
            product_partner_account_status = pproduct_partner_account_status;
            product_partner_next_interest_payment_date = pproduct_partner_next_interest_payment_date;
            interest_accrued_amount = pinterest_accrued_amount;
            employee_status = pemployee_status;
            employee_social_security_number = pemployee_social_security_number;
            family_singlefund_avail_balance = pfamily_singlefund_avail_balance;
            family_singlefund_preauth_balance = pfamily_singlefund_preauth_balance;
            family_singlefund_disbursable_balance = pfamily_singlefund_disbursable_balance;
            dependent_id = pdependent_id;
            effective_date = peffective_date;
            termination_date = ptermination_date;
            individual_rollover_avail_balance = pindividual_rollover_avail_balance;
            individual_rollover_disb_balance = pindividual_rollover_disb_balance;
            individual_rollover_preauthhold_balance = pindividual_rollover_preauthhold_balance;
            family_singlefund_rollover_amt = pfamily_singlefund_rollover_amt;
            individual_rollover_disb_PTD = pindividual_rollover_disb_PTD;
            family_singlefund_rollover_disb_balance = pfamily_singlefund_rollover_disb_balance;
            family_singlefund_rollover_disb_PTD = pfamily_singlefund_rollover_disb_PTD;
            family_singlefund_rollover_preauth_balance = pfamily_singlefund_rollover_preauth_balance;
            individual_rollover_amount = pindividual_rollover_amount;
            family_singlefund_rollover_avail_balance = pfamily_singlefund_rollover_avail_balance;
            individual_amount = pindividual_amount;
            esignature_flag = pesignature_flag;
            esignature_date = pesignature_date;
            balance_due = pbalance_due;
            coverage_start_date = pcoverage_start_date;
            coverage_end_date = pcoverage_end_date;
            life_event_type = plife_event_type;
            coverage_period_status = pcoverage_period_status;
            coverage_annual_election = pcoverage_annual_election;
            coverage_available_balance = pcoverage_available_balance;
            coverage_disbursable_balance = pcoverage_disbursable_balance;
            coverage_disbursements_PTD = pcoverage_disbursements_PTD;
            coverage_preauth_balance = pcoverage_preauth_balance;
            balance_max = pbalance_max;
            other_deposits = pother_deposits;
            family_other_deposits = pfamily_other_deposits;
            coverage_tier_id = pcoverage_tier_id;
            individual_balance_max = pindividual_balance_max;
            fund_rollover_status_code = pfund_rollover_status_code;
            family_fund_rollover_status_code = pfamily_fund_rollover_status_code;
            fund_rollover_error_code = pfund_rollover_error_code;
            family_fund_rollover_error_code = pfamily_fund_rollover_error_code;
            rollover_deposits = prollover_deposits;
            family_rollover_deposits = pfamily_rollover_deposits;
            start_autodeposit_date = pstart_autodeposit_date;
            start_fixed_employer_funding_date = pstart_fixed_employer_funding_date;
            autodeposit_calendar_id = pautodeposit_calendar_id;
            deductible_PTD = pdeductible_PTD;
            bypass_deductible_PTD = pbypass_deductible_PTD;
            current_annual_election = pcurrent_annual_election;
            enrollment_method = penrollment_method;
            employer_broker_id = pemployer_broker_id;
            claims_crossover_optin = pclaims_crossover_optin;
        }

        #endregion Class LifeCycle

        public static ArrayList GetCollection(int flag_value)
        {           
            MySqlConnection myConn = DBProxy.GetMySqlConnection();
            DBProxy.OpenConnectionForObject(ref myConn);
            MySqlCommand myCmd = new MySqlCommand("SELECT * from `ec` WHERE flag_column = " + flag_value, myConn);
            MySqlDataReader myRdr = null;
            ArrayList aCltn = new ArrayList();

            if (DBProxy.ExecuteSQLReader(ref myCmd, ref myRdr, "GETTER") == false)
            {
                if (myRdr != null && myRdr.IsClosed == false)
                    myRdr.Close();

                DBProxy.CloseConnectionForObject(ref myConn);

                return aCltn;
            }
                        
            while (myRdr.Read())
            {
                SWEC me = new SWEC(
                 (myRdr.IsDBNull(0) == true ? 0 : myRdr.GetInt32(0))
                ,(myRdr.IsDBNull(1) == true ? "" : myRdr.GetString(1))
                ,(myRdr.IsDBNull(2) == true ? "" : myRdr.GetString(2))
                ,(myRdr.IsDBNull(3) == true ? "" : myRdr.GetString(3))
                ,(myRdr.IsDBNull(4) == true ? "" : myRdr.GetString(4))
                ,(myRdr.IsDBNull(5) == true ? "" : myRdr.GetString(5))
                ,(myRdr.IsDBNull(6) == true ? "" : myRdr.GetString(6))
                ,(myRdr.IsDBNull(7) == true ? "" : myRdr.GetString(7))
                ,(myRdr.IsDBNull(8) == true ? Utility.GetNullDate() : myRdr.GetDateTime(8))
                ,(myRdr.IsDBNull(9) == true ? Utility.GetNullDate() : myRdr.GetDateTime(9))
                ,(myRdr.IsDBNull(10) == true ? "" : myRdr.GetString(10))
                ,(myRdr.IsDBNull(11) == true ? 0 : myRdr.GetDecimal(11))
                ,(myRdr.IsDBNull(12) == true ? 0 : myRdr.GetDecimal(12))
                ,(myRdr.IsDBNull(13) == true ? 0 : myRdr.GetDecimal(13))
                ,(myRdr.IsDBNull(14) == true ? "" : myRdr.GetString(14))
                ,(myRdr.IsDBNull(15) == true ? "" : myRdr.GetString(15))
                ,(myRdr.IsDBNull(16) == true ? 0 : myRdr.GetDecimal(16))
                ,(myRdr.IsDBNull(17) == true ? 0 : myRdr.GetDecimal(17))
                ,(myRdr.IsDBNull(18) == true ? 0 : myRdr.GetDecimal(18))
                ,(myRdr.IsDBNull(19) == true ? 0 : myRdr.GetDecimal(19))
                ,(myRdr.IsDBNull(20) == true ? "" : myRdr.GetString(20))
                ,(myRdr.IsDBNull(21) == true ? Utility.GetNullDate() : myRdr.GetDateTime(21))
                ,(myRdr.IsDBNull(22) == true ? Utility.GetNullDate() : myRdr.GetDateTime(22))
                ,(myRdr.IsDBNull(23) == true ? 0 : myRdr.GetDecimal(23))
                ,(myRdr.IsDBNull(24) == true ? "" : myRdr.GetString(24))
                ,(myRdr.IsDBNull(25) == true ? "" : myRdr.GetString(25))
                ,(myRdr.IsDBNull(26) == true ? "" : myRdr.GetString(26))
                ,(myRdr.IsDBNull(27) == true ? "" : myRdr.GetString(27))
                ,(myRdr.IsDBNull(28) == true ? "" : myRdr.GetString(28))
                ,(myRdr.IsDBNull(29) == true ? "" : myRdr.GetString(29))
                ,(myRdr.IsDBNull(30) == true ? "" : myRdr.GetString(30))
                ,(myRdr.IsDBNull(31) == true ? "" : myRdr.GetString(31))
                ,(myRdr.IsDBNull(32) == true ? "" : myRdr.GetString(32))
                ,(myRdr.IsDBNull(33) == true ? "" : myRdr.GetString(33))
                ,(myRdr.IsDBNull(34) == true ? "" : myRdr.GetString(34))
                ,(myRdr.IsDBNull(35) == true ? Utility.GetNullDate() : myRdr.GetDateTime(35))
                ,(myRdr.IsDBNull(36) == true ? "" : myRdr.GetString(36))
                ,(myRdr.IsDBNull(37) == true ? "" : myRdr.GetString(37))
                ,(myRdr.IsDBNull(38) == true ? Utility.GetNullDate() : myRdr.GetDateTime(38))
                ,(myRdr.IsDBNull(39) == true ? 0 : myRdr.GetDecimal(39))
                ,(myRdr.IsDBNull(40) == true ? "" : myRdr.GetString(40))
                ,(myRdr.IsDBNull(41) == true ? "" : myRdr.GetString(41))
                ,(myRdr.IsDBNull(42) == true ? 0 : myRdr.GetDecimal(42))
                ,(myRdr.IsDBNull(43) == true ? 0 : myRdr.GetDecimal(43))
                ,(myRdr.IsDBNull(44) == true ? 0 : myRdr.GetDecimal(44))
                ,(myRdr.IsDBNull(45) == true ? "" : myRdr.GetString(45))
                ,(myRdr.IsDBNull(46) == true ? Utility.GetNullDate() : myRdr.GetDateTime(46))
                ,(myRdr.IsDBNull(47) == true ? Utility.GetNullDate() : myRdr.GetDateTime(47))
                ,(myRdr.IsDBNull(48) == true ? 0 : myRdr.GetDecimal(48))
                ,(myRdr.IsDBNull(49) == true ? 0 : myRdr.GetDecimal(49))
                ,(myRdr.IsDBNull(50) == true ? 0 : myRdr.GetDecimal(50))
                ,(myRdr.IsDBNull(51) == true ? 0 : myRdr.GetDecimal(51))
                ,(myRdr.IsDBNull(52) == true ? 0 : myRdr.GetDecimal(52))
                ,(myRdr.IsDBNull(53) == true ? 0 : myRdr.GetDecimal(53))
                ,(myRdr.IsDBNull(54) == true ? 0 : myRdr.GetDecimal(54))
                ,(myRdr.IsDBNull(55) == true ? 0 : myRdr.GetDecimal(55))
                ,(myRdr.IsDBNull(56) == true ? 0 : myRdr.GetDecimal(56))
                ,(myRdr.IsDBNull(57) == true ? 0 : myRdr.GetDecimal(57))
                ,(myRdr.IsDBNull(58) == true ? 0 : myRdr.GetDecimal(58))
                ,(myRdr.IsDBNull(59) == true ? "" : myRdr.GetString(59))
                ,(myRdr.IsDBNull(60) == true ? Utility.GetNullDate() : myRdr.GetDateTime(60))
                ,(myRdr.IsDBNull(61) == true ? 0 : myRdr.GetDecimal(61))
                ,(myRdr.IsDBNull(62) == true ? Utility.GetNullDate() : myRdr.GetDateTime(62))
                ,(myRdr.IsDBNull(63) == true ? Utility.GetNullDate() : myRdr.GetDateTime(63))
                ,(myRdr.IsDBNull(64) == true ? "" : myRdr.GetString(64))
                ,(myRdr.IsDBNull(65) == true ? "" : myRdr.GetString(65))
                ,(myRdr.IsDBNull(66) == true ? 0 : myRdr.GetDecimal(66))
                ,(myRdr.IsDBNull(67) == true ? 0 : myRdr.GetDecimal(67))
                ,(myRdr.IsDBNull(68) == true ? 0 : myRdr.GetDecimal(68))
                ,(myRdr.IsDBNull(69) == true ? 0 : myRdr.GetDecimal(69))
                ,(myRdr.IsDBNull(70) == true ? 0 : myRdr.GetDecimal(70))
                ,(myRdr.IsDBNull(71) == true ? 0 : myRdr.GetDecimal(71))
                ,(myRdr.IsDBNull(72) == true ? 0 : myRdr.GetDecimal(72))
                ,(myRdr.IsDBNull(73) == true ? 0 : myRdr.GetDecimal(73))
                ,(myRdr.IsDBNull(74) == true ? "" : myRdr.GetString(74))
                ,(myRdr.IsDBNull(75) == true ? 0 : myRdr.GetDecimal(75))
                ,(myRdr.IsDBNull(76) == true ? "" : myRdr.GetString(76))
                ,(myRdr.IsDBNull(77) == true ? "" : myRdr.GetString(77))
                ,(myRdr.IsDBNull(78) == true ? "" : myRdr.GetString(78))
                ,(myRdr.IsDBNull(79) == true ? "" : myRdr.GetString(79))
                ,(myRdr.IsDBNull(80) == true ? 0 : myRdr.GetDecimal(80))
                ,(myRdr.IsDBNull(81) == true ? 0 : myRdr.GetDecimal(81))
                ,(myRdr.IsDBNull(82) == true ? Utility.GetNullDate() : myRdr.GetDateTime(82))
                ,(myRdr.IsDBNull(83) == true ? Utility.GetNullDate() : myRdr.GetDateTime(83))
                ,(myRdr.IsDBNull(84) == true ? "" : myRdr.GetString(84))
                ,(myRdr.IsDBNull(85) == true ? 0 : myRdr.GetDecimal(85))
                ,(myRdr.IsDBNull(86) == true ? 0 : myRdr.GetDecimal(86))
                ,(myRdr.IsDBNull(87) == true ? 0 : myRdr.GetDecimal(87))
                ,(myRdr.IsDBNull(88) == true ? "" : myRdr.GetString(88))
                ,(myRdr.IsDBNull(89) == true ? "" : myRdr.GetString(89))
                ,(myRdr.IsDBNull(90) == true ? "" : myRdr.GetString(90))
                    );

                aCltn.Add(me);
            }

            myRdr.Close();
            DBProxy.CloseConnectionForObject(ref myConn);

            return aCltn;
        }
    }
}

