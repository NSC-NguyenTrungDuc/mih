package nta.med.kcck.api.rpc.service.hospital.impl;

import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import nta.med.core.glossary.SessionAttribute;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.core.domain.event.HospitalEvent;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.listener.AbstractListener;
import nta.med.core.utils.BeanUtils;
import nta.med.data.mongo.medi.HospitalEventRepository;
import nta.med.kcck.api.adapter.BassAdapter;
import nta.med.kcck.api.adapter.NuroAdapter;
import nta.med.kcck.api.adapter.SystemAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;
import nta.med.kcck.api.rpc.proto.HospitalModelProto;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto.SearchHospitalInfoByHospCodeRequest;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto.SearchHospitalInfoByHospCodeResponse;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto.UpdateDefaultScheduleRequest;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;
import nta.med.kcck.api.rpc.service.AbstractRpcApiService;
import nta.med.kcck.api.rpc.service.hospital.HospitalApiService;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.impl.VertxInternal;
import org.vertx.java.core.spi.cluster.ClusterManager;

/**
 * @author dainguyen.
 */
public class HospitalApiServiceImpl extends AbstractRpcApiService implements HospitalApiService {

    @Resource
    private BassAdapter bassAdapter;
    
    @Resource
    private NuroAdapter nuroAdapter;
    
    @Resource
    private SystemAdapter systemAdapter;

    @Resource
    private HospitalEventRepository eventRepository;


    private static final Logger LOGGER = LoggerFactory.getLogger(HospitalApiServiceImpl.class);
    private HospitalEventAdapter adapter = new HospitalEventAdapter();
    public HospitalApiServiceImpl() {
        super(HospitalServiceProto.class, HospitalServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String s) {
        return true;
    }

    @RpcService(name = "GetDepartmentRequest", authenticate = true)
    public HospitalServiceProto.GetDepartmentResponse getDepartment(RpcApiSession session, HospitalServiceProto.GetDepartmentRequest request) {
        return bassAdapter.getDepartmentByHospitalCode(session, request);
    }

    @RpcService(name = "GetDoctorByDepartmentRequest", authenticate = true)
    public HospitalServiceProto.GetDoctorByDepartmentResponse getDoctors(RpcApiSession session, HospitalServiceProto.GetDoctorByDepartmentRequest request) {
    	return nuroAdapter.getDoctorByDepartment(session, request);
    }

    @RpcService(name = "SearchDoctorRequest", authenticate = true)
    public HospitalServiceProto.SearchDoctorResponse searchDoctors(RpcApiSession session, HospitalServiceProto.SearchDoctorRequest request) {
        return nuroAdapter.searchDoctors(session, request);
    }

    @RpcService(name = "SearchHospitalRequest", authenticate = true)
	public HospitalServiceProto.SearchHospitalResponse searchHospitals(RpcApiSession session, HospitalServiceProto.SearchHospitalRequest request) {
		return systemAdapter.searchHospitals(session, request);
	}
    
    @RpcService(name = "SearchHospitalInfoByHospCodeRequest", authenticate = false)
	public SearchHospitalInfoByHospCodeResponse searchHospitalByHospCode(RpcApiSession session,
			SearchHospitalInfoByHospCodeRequest request) {
    	return systemAdapter.searchHospitalByHospCode(session, request);
	}

    
    @RpcService(name = "SubscribeHospitalEventRequest", authenticate = true)
    public HospitalServiceProto.SubscribeHospitalEventResponse subscribeHospital(RpcApiSession session, HospitalServiceProto.SubscribeHospitalEventRequest request) {
        HospitalServiceProto.SubscribeHospitalEventResponse.Builder r = HospitalServiceProto.SubscribeHospitalEventResponse.newBuilder();
        r.setResult(HospitalServiceProto.SubscribeHospitalEventResponse.Result.SUCCESS);

        if(request.hasEventId() && request.getEventId() > 0) {
            List<HospitalEvent> lostEvents = eventRepository.findByIdGreaterThan(request.getEventId());
            for (HospitalEvent event : lostEvents) {
                r.addEvents(toEvent(event));
            }
        }

        session.subscribeBooking(session.getHospCode());
        return r.build();
    }
    private HospitalServiceProto.HospitalEvent toEvent(HospitalEvent event) {

        //TODO implement hospital event
        HospitalServiceProto.HospitalEvent.Builder r = HospitalServiceProto.HospitalEvent.newBuilder()
                .setId(1L).setTimestamp(1L).setHospitalId(1)
                .setType("");
        if(event != null)
        {
            BeanUtils.copyProperties(event, r, Language.JAPANESE.toString());
        }
        return r.build();
    }

    @RpcService(name = "SearchBookingScheduleRequest", authenticate = true)
    public HospitalServiceProto.SearchBookingScheduleResponse searchDoctorSchedule(RpcApiSession session, HospitalServiceProto.SearchBookingScheduleRequest request) {
        return nuroAdapter.searchDoctorSchedule(session, request);
    }
    public HospitalEventAdapter getAdapter() {
        return adapter;
    }

    public class HospitalEventAdapter extends AbstractListener<NuroServiceProto.HospitalEvent> {

        @Override
        public void onEvent(NuroServiceProto.HospitalEvent event) {
            LOGGER.info("BEGIN HospitalEventAdapter");
            for(RpcApiSession s : context.getSessions()) {
                final Rpc.RpcMessage m = RpcMessageBuilder.build(toApiEvent(event), Rpc.RpcMessage.Result.SUCCESS);
                if(m != null && s.hasSubscribedBooking(event.getHospCode())) async(null, null, "ON_HOSPITAL_EVENT", () -> { s.send(m); });
            }
        }

        private HospitalServiceProto.HospitalEvent toApiEvent(NuroServiceProto.HospitalEvent event) {
            HospitalServiceProto.HospitalEvent.Builder hospitalEvent = HospitalServiceProto.HospitalEvent.newBuilder();
            HospitalModelProto.MbsConfig.Builder mbsConfigApi = HospitalModelProto.MbsConfig.newBuilder();
            
            NuroModelProto.MbsConfig mbsConfigInfo = event.getMbsConfig();   
            BeanUtils.copyProperties(mbsConfigInfo, mbsConfigApi, Language.JAPANESE.toString());
            hospitalEvent.setHospCode(event.getHospCode());
            hospitalEvent.setMbsConfig(mbsConfigApi);
            
            hospitalEvent.setId(1L).setType("11").setHospitalId(1).setTimestamp(new Date().getTime());
            BeanUtils.copyProperties(event, hospitalEvent, "JA");
            for(NuroModelProto.Department department : event.getDeptsList())
            {
                HospitalModelProto.Department.Builder departmentItem = HospitalModelProto.Department.newBuilder();
                BeanUtils.copyProperties(department, departmentItem, "JA");
                hospitalEvent.addDepts(departmentItem);
            }
            
            return hospitalEvent.build();
        }
    }

    @RpcService(name = "VefiryAccountRequest", authenticate = true)
    public HospitalServiceProto.VefiryAccountResponse vefiryAccount(RpcApiSession session, HospitalServiceProto.VefiryAccountRequest request) {
		return systemAdapter.vefiryAccount(session, request);
    }

    @RpcService(name = "UpdateDefaultScheduleRequest", authenticate = true)
	public HospitalServiceProto.UpdateDefaultScheduleResponse updateDefaultSchedule(RpcApiSession session, HospitalServiceProto.UpdateDefaultScheduleRequest request) {
		return bassAdapter.updateDefaultSchedule(session, request);
	}

    @RpcService(name = "GetDoctorInfoRequest", authenticate = true)
    public HospitalServiceProto.GetDoctorInfoResponse getDoctorFromSession(RpcApiSession session, HospitalServiceProto.GetDoctorInfoRequest request)
    {
        HospitalServiceProto.GetDoctorInfoResponse.Builder response =  HospitalServiceProto.GetDoctorInfoResponse.newBuilder();
        SessionUserInfo sessionInfo = (SessionUserInfo) clusterMap(VertxContext.current().vertx(), request.getSessionId()).get(SessionAttribute.SESSION_USER_INFO.toString());
        //Check doctor account
        if(sessionInfo != null && (sessionInfo.getUserGroup().equals("OCS") ||
                sessionInfo.getUserGroup().equals("NUR")  || sessionInfo.getUserGroup().equals("OUT")))
        {
            HospitalModelProto.Doctor.Builder doctor =  HospitalModelProto.Doctor.newBuilder();

            doctor.setDoctorId("");
            doctor.setDoctorName(sessionInfo.getUserId());
            doctor.setDepartmentId("");
            doctor.setDoctorCode(sessionInfo.getUserId());
            doctor.setHospCode(sessionInfo.getHospitalCode());

             doctor.setDepartmentCode("01");
            response.setDoctor(doctor);
        }
        return response.build();
    }

    private Map clusterMap(Vertx vertx, String mapName){
        ClusterManager clusterManager = ((VertxInternal)vertx).clusterManager();
        Map map = clusterManager.getSyncMap(mapName);
        return map;
    }
}
