package nta.kcck.service.impl;

import java.lang.reflect.Type;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import nta.kcck.model.*;
import org.apache.commons.lang.StringUtils;
import org.codehaus.jackson.map.ObjectMapper;
import org.springframework.util.CollectionUtils;

import com.google.common.reflect.TypeToken;
import com.google.gson.Gson;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

import nta.kcck.service.IKcckScheduleService;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;

public class KcckScheduleService implements IKcckScheduleService {
	KcckApiService kcckApiService = new KcckApiService();
	// List KCCK Doctor Schedule
	@Override
	public TimeslotScheduleModel checkKcckDoctorSchedule(String hospCode, String departmentCode, String doctorCode,
														 String startDate, String endDate) {
		Map<String, Boolean> result = new LinkedHashMap<String, Boolean>();
		MessageResponse<List<KcckDoctorScheduleModel>> messageResponse = kcckApiService.getKcckDoctorSchedule(hospCode, departmentCode,
				doctorCode, startDate, endDate);
		if(messageResponse == null || CollectionUtils.isEmpty(messageResponse.getData())){
			return null;
		}
		HashSet<String> time = new HashSet<String>();
		for (int i = 0; i < messageResponse.getData().size(); i++) {
			KcckDoctorScheduleModel kcckDoctorSchedule = messageResponse.getData().get(i);
			for (KcckBookingSlot slot : kcckDoctorSchedule.getEnable_slot()) {
				String dateSlot = slot.getEnable_date_slot();
				String timeSlot = slot.getEnable_time_slot();
				String dateTimeSlot = MssDateTimeUtil.concatenateDateTime(dateSlot, timeSlot);
				result.put(dateTimeSlot, true);
				time.add(timeSlot);
			}
		}
		ArrayList<String> listTime = new ArrayList<String>(time);
		Collections.sort(listTime);
		return new TimeslotScheduleModel();
	}

	// List KCCK Department Schedule
	@Override
	public TimeslotScheduleModel checkKcckDepartmentSchedule(String hospCode, String avgTime, String startDate,
			String endDate, String departmentCode, String doctorCode, String doctorGrade) {
		Map<String, List<KcckBookingSlotModel>> result = new LinkedHashMap<String, List<KcckBookingSlotModel>>();
		MessageResponse<KcckScheduleModel> messageResponse = kcckApiService.getKcckDepartmentSchedule(hospCode, avgTime,
				startDate, endDate, departmentCode, doctorCode, doctorGrade);
		if(messageResponse == null || messageResponse.getData() == null){
			return null;
		}
		HashSet<String> time = new HashSet<String>();
		KcckScheduleModel kcckDepartmentSchedule = messageResponse.getData();
		for (KcckTimeSlot slot : kcckDepartmentSchedule.getEnable_slot()) {
			String dateSlot = slot.getEnable_date_slot();
			String timeSlot = slot.getEnable_time_slot();
			String dateTimeSlot = MssDateTimeUtil.concatenateDateTime(dateSlot, timeSlot);
			result.put(dateTimeSlot, slot.getEnable_booking());
			time.add(timeSlot);
		}
		ArrayList<String> listTime = new ArrayList<String>(time);
		return new TimeslotScheduleModel(
				this.timeList(
						kcckDepartmentSchedule.getAvg_time(),
						kcckDepartmentSchedule.getRes_am_start_hhmm(),
						kcckDepartmentSchedule.getRes_am_end_hhmm(),
						kcckDepartmentSchedule.getRes_pm_start_hhmm(),
						kcckDepartmentSchedule.getRes_pm_end_hhmm()),
				result,
				kcckDepartmentSchedule.getAvg_time());
	}

	private List<String> timeList(String avgTime, String startAm, String endAm, String startPm, String endPm){
		List<String> timeList = MssDateTimeUtil.timeList(avgTime, startAm, endAm);
		timeList.addAll(MssDateTimeUtil.timeList(avgTime, startPm, endPm));
		return timeList;
	}

	// list KCCK Doctor TimeSlot
	public List<String> listKcckDoctorTime(String hospCode, String departmentCode, String doctorCode, String startDate,
			String endDate) {
		MessageResponse<List<KcckDoctorScheduleModel>> messageResponse = kcckApiService.getKcckDoctorSchedule(hospCode, departmentCode,
				doctorCode, startDate, endDate);
		HashSet<String> time = new HashSet<String>();
		List<String> listTime = new ArrayList<String>(time);
		if (messageResponse == null || CollectionUtils.isEmpty(messageResponse.getData())){
			return listTime;
		}
		for (int i = 0; i < messageResponse.getData().size(); i++) {

			KcckDoctorScheduleModel kcckDoctorSchedule = messageResponse.getData().get(i);
			for (KcckBookingSlot slot : kcckDoctorSchedule.getEnable_slot()) {
				String timeSlot = slot.getEnable_time_slot();
				time.add(timeSlot);
			}
		}
		listTime = new ArrayList<String>(time);
		Collections.sort(listTime);
		return listTime;

	}
	
	public List<String> listKcckDepartmentTime(String hospCode, String avgTime, String startDate, String endDate,
			String departmentCode, String doctorGrade) {
		MessageResponse<List<KcckDepartmentScheduleModel>> messageResponse = new MessageResponse<>();/* kcckApiService
				.getKcckDepartmentSchedule(hospCode, avgTime, startDate, endDate, departmentCode, doctorGrade);*/
		HashSet<String> time = new HashSet<String>();
		List<String> listTime = new ArrayList<String>(time);
		if (messageResponse == null || CollectionUtils.isEmpty(messageResponse.getData())) {
			return listTime;
		}
		for (int i = 0; i < messageResponse.getData().size(); i++) {
			KcckDepartmentScheduleModel kcckDepartmentSchedule = messageResponse.getData().get(i);
			for (KcckBookingSlot slot : kcckDepartmentSchedule.getEnable_slot()) {
				String timeSlot = slot.getEnable_time_slot();
				time.add(timeSlot);
			}
		}
		listTime = new ArrayList<String>(time);
		Collections.sort(listTime);
		return listTime;
	}
}
