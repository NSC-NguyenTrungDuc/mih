package nta.med.kcck.api.adapter.impl;

import java.util.Arrays;
import java.util.List;

import org.springframework.stereotype.Component;

import nta.med.core.infrastructure.socket.adapter.AbstractAdapter;
import nta.med.kcck.api.adapter.BassAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.HospitalModelProto;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author DEV-HuanLT
 *
 */
@Component("bassAdapter")
public class BassAdapterImpl extends AbstractAdapter implements BassAdapter {

    public BassAdapterImpl() {
        super( Arrays.asList(BassServiceProto.class,  SystemServiceProto.class), BassServiceProto.getDescriptor());
     
    }

	@Override
	public HospitalServiceProto.GetDepartmentResponse getDepartmentByHospitalCode(RpcApiSession session, HospitalServiceProto.GetDepartmentRequest request) {

		HospitalServiceProto.GetDepartmentResponse.Builder r = HospitalServiceProto.GetDepartmentResponse.newBuilder();
    	
		final BassServiceProto.Bas0260GetDepartmentRequest.Builder builder = BassServiceProto.Bas0260GetDepartmentRequest.newBuilder()
	              .setHospCode(request.getHospCode()).setLocale(request.getLocale() == null ? "" : request.getLocale().toUpperCase());
		BassServiceProto.Bas0260GetDepartmentRequest req = builder.build();
		final BassServiceProto.Bas0260GetDepartmentResponse res = submit(session, req, 10000L);
        if(res != null){
        	for(BassModelProto.Bas0260DepartmetnInfo item : res.getListDepartmentList() ){
        		HospitalModelProto.Department.Builder departmentInfo = HospitalModelProto.Department.newBuilder()
						.setDepartmentId(item.getId()).setDepartmentCode(item.getGwa()).setDepartmentName(item.getGwaName()).setAvgTime(item.getAvgTime());
        		r.addDepts(departmentInfo);
        	}
        }
		return r.build();
	}

	@Override
	public HospitalServiceProto.UpdateDefaultScheduleResponse updateDefaultSchedule(RpcApiSession session, HospitalServiceProto.UpdateDefaultScheduleRequest request) {
		HospitalServiceProto.UpdateDefaultScheduleResponse.Builder response =  HospitalServiceProto.UpdateDefaultScheduleResponse.newBuilder();
		List<HospitalModelProto.Department> listDept = request.getDepartmentListList();
		
		final BassServiceProto.Bas0260UpdateDepartmentRequest.Builder builder = BassServiceProto.Bas0260UpdateDepartmentRequest.newBuilder()
	              .setHospCode(request.getHospCode()).setLocale(request.getLanguage());
		for (HospitalModelProto.Department info : listDept) {
			BassModelProto.Bas0260DepartmetnInfo.Builder item = BassModelProto.Bas0260DepartmetnInfo.newBuilder();
			item.setGwaName(info.getDepartmentName());
			item.setGwa(info.getDepartmentCode());
			item.setId(info.getDepartmentId());
			item.setAvgTime(info.getAvgTime());
			builder.addListDepartment(item);
		}
		BassServiceProto.Bas0260UpdateDepartmentRequest req = builder.build();
		final SystemServiceProto.UpdateResponse res = submit(session, req, 10000L);
		if(res != null && res.getResult()){
			response.setResult(HospitalServiceProto.UpdateDefaultScheduleResponse.Result.SUCCESS);
		}else{
			response.setResult(HospitalServiceProto.UpdateDefaultScheduleResponse.Result.INVALID);
		}
		return response.build();
	}
}
