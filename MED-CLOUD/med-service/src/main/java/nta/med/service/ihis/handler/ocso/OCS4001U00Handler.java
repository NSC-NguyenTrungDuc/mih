package nta.med.service.ihis.handler.ocso;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.time.DateUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;

import nta.med.core.domain.out.Outsang;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0501Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs4001Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.bass.BAS0501U00CareFormTemplateInfo;
import nta.med.data.model.ihis.ocso.GwaListItemInfo;
import nta.med.data.model.ihis.ocso.OCS4001U00LeftGrdViewInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS4001U00Request;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS4001U00Response;

@Service
@Scope("prototype")
public class OCS4001U00Handler extends ScreenHandler<OcsoServiceProto.OCS4001U00Request, OcsoServiceProto.OCS4001U00Response>{
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Bas0501Repository bas0501Repository;
	
	@Resource
	private Ocs4001Repository ocs4001Repository;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Override
	@Transactional(readOnly = true)
	public OCS4001U00Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS4001U00Request request) throws Exception {
		OcsoServiceProto.OCS4001U00Response.Builder response = OcsoServiceProto.OCS4001U00Response.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		if (StringUtils.isEmpty(hospCode)) {
			hospCode = getHospitalCode(vertx, sessionId);
		}
		String templateCode = "TPLHIS" + hospCode + request.getTemplateId();
		
		List<BAS0501U00CareFormTemplateInfo> bas0501List = bas0501Repository.getBas0501CareFormTemplate(hospCode, templateCode, language);
		if (!CollectionUtils.isEmpty(bas0501List)) {
			BAS0501U00CareFormTemplateInfo bas0501 = bas0501List.get(0);
			response.setInputContent(bas0501.getInputContent());
			response.setPrintContent(bas0501.getPrintContent() == null ? "" : bas0501.getPrintContent());
			response.setFormatType(bas0501.getFormatType());
			response.setTplName(bas0501.getTplName());
		}
		
		if (!StringUtils.isEmpty(request.getBunhoCode())) {
			//5
			List<String> outsangList = outsangRepository.findByBunhoHospCodeAndJuSangYn(request.getBunhoCode(), hospCode);
			if (!CollectionUtils.isEmpty(outsangList)) {
				for (String sangName : outsangList) {
					OcsoModelProto.OCS4001U00SangNameInfo.Builder info = OcsoModelProto.OCS4001U00SangNameInfo.newBuilder();
					info.setSangName(sangName);
					response.addSangNameList(info);
				}				
			}
			
			//6
			List<OCS4001U00LeftGrdViewInfo> ocs4001 = ocs4001Repository.getOcs4001LeftGrdView(hospCode, templateCode, request.getBunhoCode());
			if (!CollectionUtils.isEmpty(ocs4001)) {
				for (OCS4001U00LeftGrdViewInfo item : ocs4001) {
					OcsoModelProto.OCS4001U00ListItemInfo.Builder info = OcsoModelProto.OCS4001U00ListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					info.setId(item.getId().toString());
//					info.setCreateDate(item.getCreateDate());
//					info.setInputContent(item.getInputContent());
//					info.setInputValue(item.getInputValue());
//					info.setFormCode(item.getFormCode());
//					info.setFormName(item.getFormName());
//					info.setFormatType(item.getFormatType());
//					info.setPrintContent(item.getPrintContent());
					
					response.addItems(info);
				}
			}
			
			//8 con nay vi tra ve 2 thang String nen em lay luon GwaListItemInfo cho tien, do phai tao them model ^^
			List<GwaListItemInfo> medicineInfos = ocs1003Repository.getMedicineInfo(hospCode, request.getBunhoCode(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
			if (!CollectionUtils.isEmpty(medicineInfos)) {
				for (GwaListItemInfo item : medicineInfos) {
					OcsoModelProto.OCS4001U00PrescriptionInfo.Builder info = OcsoModelProto.OCS4001U00PrescriptionInfo.newBuilder();
					info.setHangmongName(StringUtils.isEmpty(item.getGwa()) ? "" : item.getGwa());
					info.setBogyongName(StringUtils.isEmpty(item.getBuseoName()) ? "" : item.getBuseoName());
					response.addPrescriptions(info);
				}
			}
		} else {
			//7
			List<Bas0001> hospitals = bas0001Repository.findByHospCode(hospCode);
			if (!CollectionUtils.isEmpty(hospitals)) {
				Bas0001 bas0001 = hospitals.get(0);
				OcsoModelProto.OCS4001U00HospitalInfo.Builder info = OcsoModelProto.OCS4001U00HospitalInfo.newBuilder();
				info.setYoyangName(bas0001.getYoyangName());
				info.setAddress(StringUtils.isEmpty(bas0001.getAddress()) ? "" : bas0001.getAddress());
				info.setTel(StringUtils.isEmpty(bas0001.getTel()) ? "" : bas0001.getTel());
				info.setFax(StringUtils.isEmpty(bas0001.getFax()) ? "" : bas0001.getFax());
				info.setHomepage(StringUtils.isEmpty(bas0001.getHomepage()) ? "" : bas0001.getHomepage());
				info.setEmail(StringUtils.isEmpty(bas0001.getEmail()) ? "" : bas0001.getEmail());
				response.addHospitals(info);
			}
		}
	
		return response.build();
	}

}
