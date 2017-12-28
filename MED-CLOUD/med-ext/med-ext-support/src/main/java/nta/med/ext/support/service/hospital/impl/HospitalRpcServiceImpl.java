package nta.med.ext.support.service.hospital.impl;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import nta.med.common.remoting.rpc.glossary.RpcListener;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.HospitalServiceProto.HospitalEvent;
import nta.med.ext.support.proto.HospitalServiceProto.SearchHospitalInfoByHospCodeRequest;
import nta.med.ext.support.proto.HospitalServiceProto.SearchHospitalInfoByHospCodeResponse;
import nta.med.ext.support.rpc.RpcExtContext;
import nta.med.ext.support.rpc.RpcExtSession;
import nta.med.ext.support.service.AbstractRpcExtService;
import nta.med.ext.support.service.hospital.HospitalRpcService;

/**
 * @author dainguyen.
 */
public class HospitalRpcServiceImpl extends AbstractRpcExtService implements HospitalRpcService {

    private static final Logger LOGGER = LoggerFactory.getLogger(HospitalRpcServiceImpl.class);

    private RpcExtContext.Listener<HospitalEvent> listener;

    public HospitalRpcServiceImpl() {
        super("api.hospital", HospitalServiceProto.class, HospitalServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String version) {
        return true;
    }

    @RpcListener(name = "HospitalEvent")
    public void onHospitalEvent(RpcExtSession session, HospitalEvent event) {
        if(listener != null) try {
            listener.onEvent(event);
        } catch (InterruptedException e) {
            LOGGER.warn("hospital event was interrupted, event = " + format(event));
        }
    }

    public void setListener(RpcExtContext.Listener<HospitalEvent> listener) {
        this.listener = listener;
    }

    @Override
    public HospitalServiceProto.GetDepartmentResponse getDepartment(HospitalServiceProto.GetDepartmentRequest request) {
        return invoke(request, 10000L, true);
    }

    @Override
    public HospitalServiceProto.GetDoctorByDepartmentResponse getDoctors(HospitalServiceProto.GetDoctorByDepartmentRequest request) {
        return invoke(request, 10000L, true);
    }

    @Override
    public HospitalServiceProto.SearchDoctorResponse searchDoctors(HospitalServiceProto.SearchDoctorRequest request) {
        return invoke(request, 10000L, true);
    }
    
    @Override
	public HospitalServiceProto.SearchHospitalResponse searchHospitals(HospitalServiceProto.SearchHospitalRequest request) {
    	return invoke(request, 10000L, true);
	}
    
    @Override
    public HospitalServiceProto.SubscribeHospitalEventResponse subscribeHospital(HospitalServiceProto.SubscribeHospitalEventRequest request) {
        return invoke(request, 10000L, true);
    }
    @Override
    public HospitalServiceProto.SearchBookingScheduleResponse getScheduleDoctor(HospitalServiceProto.SearchBookingScheduleRequest request)
    {
        return invoke(request, 10000L, true);
    }

	@Override
	public SearchHospitalInfoByHospCodeResponse searchHospitalInfoByHospCode(SearchHospitalInfoByHospCodeRequest request) {
		return invoke(request, 10000L, true);
	}
	
	@Override
	public HospitalServiceProto.VefiryAccountResponse vefiryAccount(HospitalServiceProto.VefiryAccountRequest request) {
		return invoke(request, 10000L, true);
	}

	@Override
	public HospitalServiceProto.UpdateDefaultScheduleResponse updateDefaultSchedule(HospitalServiceProto.UpdateDefaultScheduleRequest request) {
		return invoke(request, 10000L, true);
	}
    @Override
    public HospitalServiceProto.GetDoctorInfoResponse getDoctorFromSession(HospitalServiceProto.GetDoctorInfoRequest request )
    {
        return invoke(request, 10000L, true);
    }
}
