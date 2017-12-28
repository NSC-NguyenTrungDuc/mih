package nta.med.ext.mss.service.impl;


import nta.med.common.util.type.Triple;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.mss.HospitalRepository;
import nta.med.data.model.ihis.nuro.BookingSchedule;
import nta.med.ext.mss.model.DepartmentModel;
import nta.med.ext.mss.model.UpdateDefaultScheduleModel;
import nta.med.ext.mss.service.DepartmentService;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.proto.HospitalModelProto;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.AbstractRpcExtListener;
import nta.med.ext.support.service.hospital.HospitalRpcService;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentMap;

import static nta.med.ext.mss.glossary.ScheduleCache.doctorSchedules;

/**
 *
 * @author DEV-HuanLT
 *
 */
@Service("departmentService")
@Transactional
public class DepartmentServiceImpl implements DepartmentService {
	private static final Log LOGGER = LogFactory.getLog(DepartmentServiceImpl.class);
	@Resource
	private HospitalRpcService hospitalRpcService;

	@Resource
	private HospitalRepository hospitalRepository;

	@Override
	public List<DepartmentModel> getDepartmentByHospitalCode(String hospCode, String locale) {
		HospitalServiceProto.GetDepartmentRequest.Builder departmentRequest = HospitalServiceProto.GetDepartmentRequest.newBuilder();
		departmentRequest.setHospCode(hospCode);
		departmentRequest.setLocale(locale == null ? "" : locale);
		HospitalServiceProto.GetDepartmentResponse departmentResponse = hospitalRpcService.getDepartment(departmentRequest.build());

		List<DepartmentModel> departmentModels = new ArrayList<>();
		for(HospitalModelProto.Department department : departmentResponse.getDeptsList())
		{
			DepartmentModel departmentModel = new DepartmentModel();
			BeanUtils.copyProperties(department, departmentModel, Language.JAPANESE.toString());
			departmentModels.add(departmentModel);
		}

		return departmentModels;
	}

	public void updateMbsConfig(String hospCode, Integer useMovieTalk, Integer useSurvey, String locale) {
		if(hospitalRepository.setUpMovieTalk(hospCode, useMovieTalk, useSurvey, locale) > 0){
			LOGGER.info("Department Impl - Mbs config successfull ");
		}else{
			LOGGER.info("Department Impl - Mbs config failed ");
		}
	}

	public static class ListenerImpl extends AbstractRpcExtListener<HospitalServiceProto.HospitalEvent> {


		@Resource
		private HospitalRpcService hospitalRpcService;

		@Resource
		private DepartmentService departmentService;

		protected ListenerImpl() {
			super(HospitalServiceProto.HospitalEvent.class);
		}

		@Override
		public EventMetaStore meta() {
			return EventMetaStore.HOSPITAL;
		}

		@Override
		public void handleEvent(HospitalServiceProto.HospitalEvent event)  {
			try
			{
				LOGGER.info("Department Impl:"+ event.getId());
				if(event != null)
				{
					if(CollectionUtils.isEmpty(event.getDeptsList()) && event.getHospCode() != null)
					{
						LOGGER.info("Department Impl is Empty Depts with hospCode: " + event.getHospCode());
						for (Map.Entry<String, Triple<Boolean, String, ConcurrentMap<String,  Map<String, List<BookingSchedule>>>>> entry : doctorSchedules.entrySet())
						{
							String[] items = entry.getKey().split("-");
							LOGGER.info("Department Impl is Empty Depts with item: " +items);
							if(items.length > 0 && items[0].equals(event.getHospCode()))
							{
								LOGGER.info("Department Impl is Empty Depts with item 0: " +items[0]);
								LOGGER.info("Department Impl entry key: " +entry.getKey());
								doctorSchedules.get(entry.getKey()).getV3().clear();
							}
						}
					}

					//update hospital using movie talk
					try
					{
						if(event.getMbsConfig() != null && event.getHospCode() != null)
						{
								LOGGER.info("Update mbs config");
								departmentService.updateMbsConfig(event.getHospCode(), CommonUtils.parseInteger(event.getMbsConfig().getUseMovieTalk()),
										CommonUtils.parseInteger(event.getMbsConfig().getUseSurvey()), event.getMbsConfig().getLocale());
						}
					}
					catch (Exception e)
					{
						LOGGER.error("Exception in Department updateMbsConfig ", e);
					}

					//clear cache for hosp_code and department_code
					for(HospitalModelProto.Department department : event.getDeptsList())
					{
						LOGGER.info("Department Impl HospCode: " + event.getHospCode());
						if(event.getHospCode() != null)
						{
							LOGGER.info("Department Impl HospCode with key1 ");
							LOGGER.info("Department Impl HospCode with key: "+event.getHospCode());
							LOGGER.info("Department Impl HospCode with key: "+ department.getDepartmentCode());
							final String key1 = String.format("%s-%s", event.getHospCode(), department.getDepartmentCode());
							LOGGER.info("Department Impl key 1 is: " + key1);
							LOGGER.info("Department Impl doctorSchedules" + doctorSchedules);
							LOGGER.info("Department Impl doctorSchedules get key 1" + doctorSchedules.get(key1));
							if(doctorSchedules.get(key1) != null)
							{
								LOGGER.info("Department Impl clear cache for key: " + key1);
								doctorSchedules.get(key1).getV3().clear();
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				LOGGER.error("Exception in Department ListenerImpl ", e);
			}



		}

		@Override
		public Collection<HospitalServiceProto.HospitalEvent> invokeSubscribe(long eventId) throws Exception {
			HospitalServiceProto.SubscribeHospitalEventRequest request = HospitalServiceProto.SubscribeHospitalEventRequest
					.newBuilder().setEventId(-1L).build();
			HospitalServiceProto.SubscribeHospitalEventResponse response = hospitalRpcService.subscribeHospital(request);
			if (response != null && PatientServiceProto.SubscribePatientEventResponse.Result.SUCCESS.equals(response.getResult())) {
				if (isVerbose()) LOGGER.info("{} was successfully subscribed");
				return response.getEventsList();
			}

			return java.util.Collections.emptyList();
		}
	}
	@Override
	public String updateDefaultSchedule(UpdateDefaultScheduleModel updateDefaultSchedule) {
		HospitalServiceProto.UpdateDefaultScheduleRequest.Builder builder = HospitalServiceProto.UpdateDefaultScheduleRequest.newBuilder();
		builder.setHospCode(updateDefaultSchedule.getHospCode());
		builder.setLanguage(updateDefaultSchedule.getLanguage());
		for (DepartmentModel item : updateDefaultSchedule.getDeptList()) {
			HospitalModelProto.Department.Builder departmentModel = HospitalModelProto.Department.newBuilder();
			departmentModel.setDepartmentId(item.getDepartmentId());
			departmentModel.setDepartmentCode(item.getDepartmentCode());
			departmentModel.setDepartmentName("");
			departmentModel.setAvgTime(item.getAvgTime());
			builder.addDepartmentList(departmentModel);
		}

		HospitalServiceProto.UpdateDefaultScheduleRequest request = builder.build();
		HospitalServiceProto.UpdateDefaultScheduleResponse response = hospitalRpcService.updateDefaultSchedule(request);
		doctorSchedules.clear();
		return response.toString();
	}
}
