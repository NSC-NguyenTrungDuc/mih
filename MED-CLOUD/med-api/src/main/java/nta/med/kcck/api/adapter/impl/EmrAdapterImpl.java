package nta.med.kcck.api.adapter.impl;

import java.util.List;

import org.springframework.stereotype.Component;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.adapter.AbstractAdapter;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.adapter.EmrAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.SystemModelProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto.GetEmrDataRequest;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;

/**
 * @author dainguyen.
 */
@Component("emrAdapter")
public class EmrAdapterImpl extends AbstractAdapter implements EmrAdapter {

    public EmrAdapterImpl() {
        super(EmrServiceProto.class, EmrServiceProto.getDescriptor());
    }

    @Override
	public  nta.med.kcck.api.rpc.proto.SystemServiceProto.GetEmrDataResponse getEmrData(RpcApiSession session, GetEmrDataRequest req) {
		nta.med.kcck.api.rpc.proto.SystemServiceProto.GetEmrDataResponse.Builder emrResponse =  nta.med.kcck.api.rpc.proto.SystemServiceProto.GetEmrDataResponse.newBuilder();
    	final EmrServiceProto.EMRGetByPatientCodeAndHospCodeRequest request = EmrServiceProto.EMRGetByPatientCodeAndHospCodeRequest
				.newBuilder()
				.setPatientCode(req.getPatientCode())
				.setHospCode(req.getHospCode())
				.build();
		
		final EmrServiceProto.EMRGetByPatientCodeAndHospCodeResponse response = submit(session, request, 10000L);
		
        if(response != null){
        	emrResponse.setContent(response.getContent());
        	emrResponse.setVersion(response.getVersion());
        	List<EmrModelProto.EmrTagInfo> listEmrTag = response.getEmrTagInfoList();
            for (EmrModelProto.EmrTagInfo info: listEmrTag) {
            	SystemModelProto.EmrTagInfo.Builder item = SystemModelProto.EmrTagInfo.newBuilder();
            	BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
            	emrResponse.addEmrTagInfo(item);
            }
        }
		return emrResponse.build();
	}

}
