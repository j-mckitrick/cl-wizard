<?php

/**
 * DB class generated from table: eb
 *
 * Uses sprocs.
 *
 * @author Jonathon McKitrick
 */
class Eb
{
    public $id;
    public $record_id;
    public $tpa_id;
    public $employer_id;
    public $employee_id;
    public $prefix;
    public $lastname;
    public $firstname;
    public $middleinitial;
    public $phone;
    public $address_line1;
    public $address_line2;
    public $city;
    public $state;
    public $zip;
    public $country;
    public $reimbursement_code;
    public $email;
    public $userdefined_field;
    public $employee_status;
    public $gender;
    public $marital_status;
    public $shippingaddress_line1;
    public $shippingaddress_line2;
    public $shippingaddress_city;
    public $shippingaddress_state;
    public $shippingaddress_zip;
    public $shippingaddress_country;
    public $birthdate;
    public $bank_routing_number;
    public $bank_account_number;
    public $bank_account_type_code;
    public $remarks;
    public $employee_ssn;
    public $health_plan_id;
    public $dental_id;
    public $vision_id;
    public $pbm_id;
    public $healthcare_coverage_default;
    public $medical_coverage;
    public $pharmacy_coverage;
    public $dental_coverage;
    public $hospital_coverage;
    public $vision_coverage;
    public $hearing_coverage;
    public $eligibility_date;
    public $last_updated;
    public $last_updated_time;
    public $card_number;
    public $termination_date;
    public $division;
    public $employer_name;
    public $card_design_id;
    public $converted_to_participant;
    public $synced_to_sidewinder;
    public $medicare_hicn;
    public $notes;

	public function __construct()
	{
        $this->id = 0;
        $this->record_id = '';
        $this->tpa_id = '';
        $this->employer_id = '';
        $this->employee_id = '';
        $this->prefix = '';
        $this->lastname = '';
        $this->firstname = '';
        $this->middleinitial = '';
        $this->phone = '';
        $this->address_line1 = '';
        $this->address_line2 = '';
        $this->city = '';
        $this->state = '';
        $this->zip = '';
        $this->country = '';
        $this->reimbursement_code = '';
        $this->email = '';
        $this->userdefined_field = '';
        $this->employee_status = '';
        $this->gender = '';
        $this->marital_status = '';
        $this->shippingaddress_line1 = '';
        $this->shippingaddress_line2 = '';
        $this->shippingaddress_city = '';
        $this->shippingaddress_state = '';
        $this->shippingaddress_zip = '';
        $this->shippingaddress_country = '';
        $this->birthdate = '';
        $this->bank_routing_number = '';
        $this->bank_account_number = '';
        $this->bank_account_type_code = '';
        $this->remarks = '';
        $this->employee_ssn = '';
        $this->health_plan_id = '';
        $this->dental_id = '';
        $this->vision_id = '';
        $this->pbm_id = '';
        $this->healthcare_coverage_default = '';
        $this->medical_coverage = '';
        $this->pharmacy_coverage = '';
        $this->dental_coverage = '';
        $this->hospital_coverage = '';
        $this->vision_coverage = '';
        $this->hearing_coverage = '';
        $this->eligibility_date = '';
        $this->last_updated = '';
        $this->last_updated_time = '';
        $this->card_number = '';
        $this->termination_date = '';
        $this->division = '';
        $this->employer_name = '';
        $this->card_design_id = '';
        $this->converted_to_participant = 0;
        $this->synced_to_sidewinder = 0;
        $this->medicare_hicn = '';
        $this->notes = '' /* XXX */;
	}

	/**
	 * Populate this Eb from a db result.
	 *
	 * @param mixed $result
	 */
	public function populate_from_result($result)
	{
        if ($result['return_type'] == 'none')
            return false;

        $this->id = $result['id'];
        $this->record_id = $result['record_id'];
        $this->tpa_id = $result['tpa_id'];
        $this->employer_id = $result['employer_id'];
        $this->employee_id = $result['employee_id'];
        $this->prefix = $result['prefix'];
        $this->lastname = $result['lastname'];
        $this->firstname = $result['firstname'];
        $this->middleinitial = $result['middleinitial'];
        $this->phone = $result['phone'];
        $this->address_line1 = $result['address_line1'];
        $this->address_line2 = $result['address_line2'];
        $this->city = $result['city'];
        $this->state = $result['state'];
        $this->zip = $result['zip'];
        $this->country = $result['country'];
        $this->reimbursement_code = $result['reimbursement_code'];
        $this->email = $result['email'];
        $this->userdefined_field = $result['userdefined_field'];
        $this->employee_status = $result['employee_status'];
        $this->gender = $result['gender'];
        $this->marital_status = $result['marital_status'];
        $this->shippingaddress_line1 = $result['shippingaddress_line1'];
        $this->shippingaddress_line2 = $result['shippingaddress_line2'];
        $this->shippingaddress_city = $result['shippingaddress_city'];
        $this->shippingaddress_state = $result['shippingaddress_state'];
        $this->shippingaddress_zip = $result['shippingaddress_zip'];
        $this->shippingaddress_country = $result['shippingaddress_country'];
        $this->birthdate = $result['birthdate'];
        $this->bank_routing_number = $result['bank_routing_number'];
        $this->bank_account_number = $result['bank_account_number'];
        $this->bank_account_type_code = $result['bank_account_type_code'];
        $this->remarks = $result['remarks'];
        $this->employee_ssn = $result['employee_ssn'];
        $this->health_plan_id = $result['health_plan_id'];
        $this->dental_id = $result['dental_id'];
        $this->vision_id = $result['vision_id'];
        $this->pbm_id = $result['pbm_id'];
        $this->healthcare_coverage_default = $result['healthcare_coverage_default'];
        $this->medical_coverage = $result['medical_coverage'];
        $this->pharmacy_coverage = $result['pharmacy_coverage'];
        $this->dental_coverage = $result['dental_coverage'];
        $this->hospital_coverage = $result['hospital_coverage'];
        $this->vision_coverage = $result['vision_coverage'];
        $this->hearing_coverage = $result['hearing_coverage'];
        $this->eligibility_date = $result['eligibility_date'];
        $this->last_updated = $result['last_updated'];
        $this->last_updated_time = $result['last_updated_time'];
        $this->card_number = $result['card_number'];
        $this->termination_date = $result['termination_date'];
        $this->division = $result['division'];
        $this->employer_name = $result['employer_name'];
        $this->card_design_id = $result['card_design_id'];
        $this->converted_to_participant = $result['converted_to_participant'];
        $this->synced_to_sidewinder = $result['synced_to_sidewinder'];
        $this->medicare_hicn = $result['medicare_hicn'];
        $this->notes = $result['notes'];

        return $this;
	}

	/**
	 * Get a Eb by id.
	 *
	 * @param integer $id the desired Eb
	 * @param resource $db database handle
	 * @return Eb
	 */
	public function get($id, $db)
	{
		$sql = "SELECT * FROM `eb` WHERE id = $id";

		$result = $db->query($sql);

		return $this->populate_from_result($result);
	}

	/**
	 * Get a list of Eb rows by a specific column and value.
	 *
	 * @param string $column to be searched
	 * @param string $value to be matched
	 * @param resource $db database handle
	 * @return Eb
	 */
	public function get_by($column, $value, $db)
	{
		$sql = "SELECT * FROM `eb` WHERE " .
			$column . " = '" .
			$value .
			"'";

		return $db->query($sql);
	}

	/**
	 * Get a Eb by a specific column and value.
	 *
	 * @param string $column to be searched
	 * @param string $value to be matched
	 * @param resource $db database handle
	 * @return Eb
	 */
	public function get_one_by($column, $value, $db)
	{
		$sql = "SELECT * FROM `eb` WHERE $column = '$value' LIMIT 1";

		$result = $db->query($sql);

		return $this->populate_from_result($result);
	}

	/**
	 * Get a list of Ebs by a specific column and value.
	 *
	 * @param integer $limit max result count
	 * @param string $column to be searched
	 * @param string $value to be matched
	 * @param resource $db database handle
	 * @return array of db rows
	 */
	public function getlist($limit, $column, $value, $db)
	{
		$sql = "SELECT * FROM `eb` WHERE " . $column . " IN (" . $value . ") LIMIT " . $limit;

		return $db->query($sql);
	}

	/**
	 * Get a list of Ebs.
	 *
	 * @param integer $limit max result count
	 * @param resource $db database handle
	 * @return array of db rows
	 */
	public function getall($limit, $db)
	{
		$sql = "SELECT * FROM `eb` LIMIT $limit";

		return $db->query($sql);
	}

	/**
	 * Save this Eb.
	 *
	 * @param resource $db database handle
	 */
	public function save($db)
	{
		if ($this->id == 0)
		{
			$sql = 'CALL SP_InsertIntoEb' .
				"('$this->record_id', '$this->tpa_id', '$this->employer_id', '$this->employee_id', '$this->prefix', '$this->lastname', '$this->firstname', '$this->middleinitial', '$this->phone', '$this->address_line1', '$this->address_line2', '$this->city', '$this->state', '$this->zip', '$this->country', '$this->reimbursement_code', '$this->email', '$this->userdefined_field', '$this->employee_status', '$this->gender', '$this->marital_status', '$this->shippingaddress_line1', '$this->shippingaddress_line2', '$this->shippingaddress_city', '$this->shippingaddress_state', '$this->shippingaddress_zip', '$this->shippingaddress_country', '$this->birthdate', '$this->bank_routing_number', '$this->bank_account_number', '$this->bank_account_type_code', '$this->remarks', '$this->employee_ssn', '$this->health_plan_id', '$this->dental_id', '$this->vision_id', '$this->pbm_id', '$this->healthcare_coverage_default', '$this->medical_coverage', '$this->pharmacy_coverage', '$this->dental_coverage', '$this->hospital_coverage', '$this->vision_coverage', '$this->hearing_coverage', '$this->eligibility_date', '$this->last_updated', '$this->last_updated_time', '$this->card_number', '$this->termination_date', '$this->division', '$this->employer_name', '$this->card_design_id', $this->converted_to_participant, $this->synced_to_sidewinder, '$this->medicare_hicn', '$this->notes')";
		}
		else
		{
			$sql = 'CALL SP_UpdateEbByID' .
				"($this->id, '$this->record_id', '$this->tpa_id', '$this->employer_id', '$this->employee_id', '$this->prefix', '$this->lastname', '$this->firstname', '$this->middleinitial', '$this->phone', '$this->address_line1', '$this->address_line2', '$this->city', '$this->state', '$this->zip', '$this->country', '$this->reimbursement_code', '$this->email', '$this->userdefined_field', '$this->employee_status', '$this->gender', '$this->marital_status', '$this->shippingaddress_line1', '$this->shippingaddress_line2', '$this->shippingaddress_city', '$this->shippingaddress_state', '$this->shippingaddress_zip', '$this->shippingaddress_country', '$this->birthdate', '$this->bank_routing_number', '$this->bank_account_number', '$this->bank_account_type_code', '$this->remarks', '$this->employee_ssn', '$this->health_plan_id', '$this->dental_id', '$this->vision_id', '$this->pbm_id', '$this->healthcare_coverage_default', '$this->medical_coverage', '$this->pharmacy_coverage', '$this->dental_coverage', '$this->hospital_coverage', '$this->vision_coverage', '$this->hearing_coverage', '$this->eligibility_date', '$this->last_updated', '$this->last_updated_time', '$this->card_number', '$this->termination_date', '$this->division', '$this->employer_name', '$this->card_design_id', $this->converted_to_participant, $this->synced_to_sidewinder, '$this->medicare_hicn', '$this->notes')";
		}

		$result = $db->query($sql);

		if ($item = item_from_db_result($result))
			$this->id = $item['id'];
	}

	/**
	 * Delete this Eb.
	 *
	 * @param resource $db database handle
	 */
	public function delete($db)
	{
		$sql = "CALL SP_DeleteEbByID($this->id)";
		$result = $db->stock_query($sql);
		$db->free_result($result);
	}
}

