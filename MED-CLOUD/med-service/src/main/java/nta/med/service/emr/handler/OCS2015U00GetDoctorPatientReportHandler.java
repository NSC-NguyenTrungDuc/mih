package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.emr.OCS2015U00GetDiseaseReportInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetDoctorInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetOrderReportInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetPatientInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;

@Service
@Scope("prototype")
public class OCS2015U00GetDoctorPatientReportHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetDoctorPatientReportRequest, EmrServiceProto.OCS2015U00GetDoctorPatientReportResponse> {

    @Resource
    Ocs1003Repository ocs1003Repository;
    @Resource
    OutsangRepository outsangRepository;
    @Resource
    Bas0270Repository bas0270Repository;
    @Resource
    Out0101Repository out0101Repository;
    @Resource
    CommonRepository commonRepository;

    @Override
    @Transactional
    public EmrServiceProto.OCS2015U00GetDoctorPatientReportResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00GetDoctorPatientReportRequest request) throws Exception {
        EmrServiceProto.OCS2015U00GetDoctorPatientReportResponse.Builder response = EmrServiceProto.OCS2015U00GetDoctorPatientReportResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        String bunho = request.getBunho();
        Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
        String doctor = request.getDoctor();
        EmrModelProto.OCS2015U00GetDoctorPatientReportInfo.Builder doctorBuilder = EmrModelProto.OCS2015U00GetDoctorPatientReportInfo.newBuilder();
        // doctor information 
        OCS2015U00GetDoctorInfo doctorInfo = bas0270Repository.getOCS2015U00GetDoctorInfo(hospCode, language, doctor);
        if(doctorInfo != null){
        	if(!StringUtils.isEmpty(doctorInfo.getDoctorName())){
        		doctorBuilder.setDoctorName(doctorInfo.getDoctorName());
        	}
        	if(!StringUtils.isEmpty(doctorInfo.getGwaName())){
        		doctorBuilder.setGwaName(doctorInfo.getGwaName());
        	}
        	if(!StringUtils.isEmpty(doctorInfo.getYotangName2())){
        		doctorBuilder.setYotangName(doctorInfo.getYotangName2());
        	}
        	if(!StringUtils.isEmpty(doctorInfo.getAddress())){
        		doctorBuilder.setAdressDoc(doctorInfo.getAddress());
        	}
        	if(!StringUtils.isEmpty(doctorInfo.getTel1())){
        		doctorBuilder.setTelDoc(doctorInfo.getTel1());
        	}
        	if(!StringUtils.isEmpty(doctorInfo.getFax())){
        		doctorBuilder.setFaxDoc(doctorInfo.getFax());
        	}
        	if(!StringUtils.isEmpty(doctorInfo.getWebsite())){
        		doctorBuilder.setWebsite(doctorInfo.getWebsite());
        	}
        }
        //Get medical number 
        String seqValue = commonRepository.getNextVal("MISA_BADT_SEQ");
        if(!StringUtils.isEmpty(seqValue)){
        	doctorBuilder.setSeqvalue(seqValue);
        }
        //Get patient information
        OCS2015U00GetPatientInfo patientInfo = out0101Repository.getOCS2015U00GetPatientInfo(hospCode, bunho);
        if(patientInfo != null){
        	if(!StringUtils.isEmpty(patientInfo.getSuname())){
        		doctorBuilder.setSuname(patientInfo.getSuname());
        	}
        	if(!StringUtils.isEmpty(patientInfo.getBirth())){
        		doctorBuilder.setBirth(patientInfo.getBirth());
        	}
        	if(!StringUtils.isEmpty(patientInfo.getSex())){
        		doctorBuilder.setSex(patientInfo.getSex());
        	}
        	if(!StringUtils.isEmpty(patientInfo.getAddress())){
        		doctorBuilder.setAdressPa(patientInfo.getAddress());
        	}
        	if(!StringUtils.isEmpty(patientInfo.getTel())){
        		doctorBuilder.setTelPa(patientInfo.getTel());
        	}
        }
        response.setListItem(doctorBuilder);
        //Get disease information
        List<OCS2015U00GetDiseaseReportInfo> listDisease = outsangRepository.getOCS2015U00GetDiseaseReportInfo(hospCode, request.getGwa(), bunho, 
        		DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD));
        if(!CollectionUtils.isEmpty(listDisease)){
        	for(OCS2015U00GetDiseaseReportInfo item : listDisease){
        		EmrModelProto.OCS2015U00GetDiseaseReportInfo.Builder info = EmrModelProto.OCS2015U00GetDiseaseReportInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListDisease(info);
			}
        }
        // Get order information
        List<OCS2015U00GetOrderReportInfo> listOrderReport = ocs1003Repository.getOCS2015U00GetOrderReportInfo(hospCode, language, bunho, pkout1001);
        if(!CollectionUtils.isEmpty(listOrderReport)){
        	for(OCS2015U00GetOrderReportInfo item : listOrderReport){
        		EmrModelProto.OCS2015U00GetOrderReportInfo.Builder info = EmrModelProto.OCS2015U00GetOrderReportInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListOrder(info);
			}
        }
        return response.build();
    }
}
