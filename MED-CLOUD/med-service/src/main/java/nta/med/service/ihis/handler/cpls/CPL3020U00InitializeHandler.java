//package nta.med.service.ihis.handler.cpls;
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.data.dao.medi.adm.Adm3200Repository;
//import nta.med.data.dao.medi.cpl.Cpl0109Repository;
//import nta.med.data.dao.medi.cpl.Cpl0111Repository;
//import nta.med.data.dao.medi.cpl.Cpl2090Repository;
//import nta.med.data.dao.medi.out.Out0101Repository;
//import nta.med.data.model.ihis.common.ComboListItemInfo;
//import nta.med.data.model.ihis.cpls.CPL3020U00DsvNoteListItemInfo;
//import nta.med.data.model.ihis.cpls.CPL3020U00GrdPaListItemInfo;
//import nta.med.data.model.ihis.cpls.CPL3020U00GrdResultListItemInfo;
//import nta.med.service.ScreenHandler;
//import nta.med.service.ihis.proto.CommonModelProto;
//import nta.med.service.ihis.proto.CplsModelProto;
//import nta.med.service.ihis.proto.CplsServiceProto;
//
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.transaction.annotation.Transactional;
//import org.springframework.util.StringUtils;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.eventbus.Message;
//
//import com.google.protobuf.InvalidProtocolBufferException;
//
//@Transactional
//@Service
//@Scope("prototype")
//public class CPL3020U00InitializeHandler extends ScreenHandler implements Handler<Message<byte[]>> {
//	private static final Log LOGGER = LogFactory.getLog(CPL3020U00InitializeHandler.class);
//	@Resource
//	private Cpl2090Repository cpl2090Repository;
//	@Resource
//	private Cpl0109Repository cpl0109Repository;
//	@Resource
//	private Cpl0111Repository cpl0111Repository;
//	@Resource
//	private Adm3200Repository adm3200Repository;
//	@Resource
//	private Out0101Repository out0101Repository;
//	
//	@Override
//	public void handle(Message<byte[]> message) {
//		Rpc.RpcMessage rpcMessage;
//        try {
//    		LOGGER.info("[START] CPL3020U00InitializeHandler");
//            rpcMessage = Rpc.RpcMessage.parseFrom(message.body());
//            CplsServiceProto.CPL3020U00InitializeRequest request = CplsServiceProto.CPL3020U00InitializeRequest.parseFrom(rpcMessage.getPayloadData());
//            LOGGER.info("REQUEST: " + request.toString());
//            Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);
//            CplsServiceProto.CPL3020U00InitializeResponse.Builder response = CplsServiceProto.CPL3020U00InitializeResponse.newBuilder();
//            try{
//            	List<CPL3020U00DsvNoteListItemInfo> listCPL3020U00DsvNoteListItem = cpl2090Repository.getCPL3020U00DsvNoteListItem(getHospitalCode(), request.getSpecimenSerDsvNote(), request.getJundalGubunDsvNote());
//            	if(listCPL3020U00DsvNoteListItem != null && !listCPL3020U00DsvNoteListItem.isEmpty()){
//            		for(CPL3020U00DsvNoteListItemInfo item : listCPL3020U00DsvNoteListItem){
//            			CplsModelProto.CPL3020U00DsvNoteListItemInfo.Builder info = CplsModelProto.CPL3020U00DsvNoteListItemInfo.newBuilder();
//            			if (!StringUtils.isEmpty(item.getJundalPart())) {
//            				info.setJundalPart(item.getJundalPart());
//            			}
//            			if (!StringUtils.isEmpty(item.getSpecimenSer())) {
//            				info.setSpecimenSer(item.getSpecimenSer());
//            			}
//            			if (!StringUtils.isEmpty(item.getNote())) {
//            				info.setNote(item.getNote());
//            			}
//            			if (!StringUtils.isEmpty(item.getCode())) {
//            				info.setCode(item.getCode());
//            			}
//            			if (!StringUtils.isEmpty(item.getEtcComment())) {
//            				info.setEtcComment(item.getEtcComment());
//            			}
//
//            			response.addDsvNoteList(info);
//            		}
//            	}
//            	
//            	List<ComboListItemInfo> listFwkJundalGubunList = cpl0109Repository.getFwkJundalGubunListItem(getHospitalCode(), request.getCodeTypeFwkJundalGubun(),request.getFind1FwkJundalGubun(),getLanguage());
//            	if(listFwkJundalGubunList != null && !listFwkJundalGubunList.isEmpty()){
//            		for(ComboListItemInfo item : listFwkJundalGubunList){
//            			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
//            			if (!StringUtils.isEmpty(item.getCode())) {
//            				info.setCode(item.getCode());
//            			}
//            			if (!StringUtils.isEmpty(item.getCodeName())) {
//            				info.setCodeName(item.getCodeName());
//            			}
//            			response.addFwkJundalGubunList(info);
//            		}
//            	}
//            	
//            	List<ComboListItemInfo> listFwkNoteList = cpl0111Repository.getFwkNoteListItem(getHospitalCode(), request.getJundalGubunFwkNote(),request.getFind1FwkNote());
//            	if(listFwkNoteList != null && !listFwkNoteList.isEmpty()){
//            		for(ComboListItemInfo item : listFwkNoteList){
//            			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
//            			if (!StringUtils.isEmpty(item.getCode())) {
//            				info.setCode(item.getCode());
//            			}
//            			if (!StringUtils.isEmpty(item.getCodeName())) {
//            				info.setCodeName(item.getCodeName());
//            			}
//            			response.addFwkNoteList(info);
//            		}
//            	}
//            	
//            	List<CPL3020U00GrdPaListItemInfo> listGrdPaList = out0101Repository.getGrdPaListItem(getHospitalCode(), request.getJundalGubunGrdPa(), request.getGubunGrdPa(),
//            			request.getFromDateGrdPa(), request.getToDateGrdPa());
//            	if(listGrdPaList != null && !listGrdPaList.isEmpty()){
//            		for(CPL3020U00GrdPaListItemInfo item : listGrdPaList){
//            			CplsModelProto.CPL3020U00GrdPaListItemInfo.Builder info = CplsModelProto.CPL3020U00GrdPaListItemInfo.newBuilder();
//            			if (!StringUtils.isEmpty(item.getLabNo())) {
//            				info.setLabNo(item.getLabNo());
//            			}
//            			if (!StringUtils.isEmpty(item.getSuname())) {
//            				info.setSuname(item.getSuname());
//            			}
//            			if (!StringUtils.isEmpty(item.getSpecimenSer())) {
//            				info.setSpecimenSer(item.getSpecimenSer());
//            			}
//            			if (!StringUtils.isEmpty(item.getLabSort())) {
//            				info.setLabSort(item.getLabSort());
//            			}
//            			if (!StringUtils.isEmpty(item.getPartJubsuDate())) {
//            				info.setPartJubsuDate(item.getPartJubsuDate().toString());
//            			}
//            			if (!StringUtils.isEmpty(item.getJundalGubun())) {
//            				info.setJundalGubun(item.getJundalGubun());
//            			}
//            			if (!StringUtils.isEmpty(item.getGubun())) {
//            				info.setGubun(item.getGubun());
//            			}
//            			if (!StringUtils.isEmpty(item.getResultYn())) {
//            				info.setResultYn(item.getResultYn());
//            			}
//            			if (!StringUtils.isEmpty(item.getConfirmYn())) {
//            				info.setConfirmYn(item.getConfirmYn());
//            			}
//            			response.addGrdPaList(info);
//            		}
//            	}
//            	List<CPL3020U00GrdResultListItemInfo> listGrdResultList = cpl0109Repository.getGrdResultListItem(getHospitalCode(), getLanguage(), request.getLabNoGrdResult(),request.getSpecimenSerGrdResult(),
//            			request.getJundalGubunGrdResult(),request.getCodeTypeGrdResult());
//            	if(listGrdResultList != null && !listGrdResultList.isEmpty()){
//            		for(CPL3020U00GrdResultListItemInfo item : listGrdResultList){
//            			CplsModelProto.CPL3020U00GrdResultListItemInfo.Builder info = CplsModelProto.CPL3020U00GrdResultListItemInfo.newBuilder();
//            			if (!StringUtils.isEmpty(item.getPkcpl3020())) {
//            				info.setPkcpl3020(item.getPkcpl3020().toString());
//            			}
//            			if (!StringUtils.isEmpty(item.getGumsaName())) {
//            				info.setGumsaName(item.getGumsaName());
//            			}
//            			if (!StringUtils.isEmpty(item.getStandardYn())) {
//            				info.setStandardYn(item.getStandardYn());
//            			}
//            			if (!StringUtils.isEmpty(item.getCplResult())) {
//            				info.setCplResult(item.getCplResult());
//            			}
//            			if (!StringUtils.isEmpty(item.getConfirmYn())) {
//            				info.setConfirmYn(item.getConfirmYn());
//            			}
//            			if (!StringUtils.isEmpty(item.getBeforeResult())) {
//            				info.setBeforeResult(item.getBeforeResult());
//            			}
//            			if (!StringUtils.isEmpty(item.getPanicYn())) {
//            				info.setPanicYn(item.getPanicYn());
//            			}
//            			if (!StringUtils.isEmpty(item.getDeltaYn())) {
//            				info.setDeltaYn(item.getDeltaYn());
//            			}
//            			if (!StringUtils.isEmpty(item.getDanuiName())) {
//            				info.setDanuiName(item.getDanuiName());
//            			}
//            			if (!StringUtils.isEmpty(item.getStandard())) {
//            				info.setStandard(item.getStandard());
//            			}
//            			if (!StringUtils.isEmpty(item.getComments())) {
//            				info.setComments(item.getComments());
//            			}
//            			if (!StringUtils.isEmpty(item.getFkocs())) {
//            				info.setFkocs(item.getFkocs().toString());
//            			}
//            			if (!StringUtils.isEmpty(item.getFkcpl2010())) {
//            				info.setFkcpl2010(item.getFkcpl2010().toString());
//            			}
//            			if (!StringUtils.isEmpty(item.getLabNo())) {
//            				info.setLabNo(item.getLabNo());
//            			}
//            			if (!StringUtils.isEmpty(item.getHangmogCode())) {
//            				info.setHangmogCode(item.getHangmogCode());
//            			}
//            			if (!StringUtils.isEmpty(item.getSpecimenCode())) {
//            				info.setSpecimenCode(item.getSpecimenCode());
//            			}
//            			if (!StringUtils.isEmpty(item.getEmergency())) {
//            				info.setEmergency(item.getEmergency());
//            			}
//            			if (!StringUtils.isEmpty(item.getGumsaja())) {
//            				info.setGumsaja(item.getGumsaja());
//            			}
//            			if (!StringUtils.isEmpty(item.getBunho())) {
//            				info.setBunho(item.getBunho());
//            			}
//            			if (!StringUtils.isEmpty(item.getResultDate())) {
//            				info.setResultDate(item.getResultDate());
//            			}
//            			if (!StringUtils.isEmpty(item.getSpecimenSer())) {
//            				info.setSpecimenSer(item.getSpecimenSer());
//            			}
//            			if (!StringUtils.isEmpty(item.getResultForm())) {
//            				info.setResultForm(item.getResultForm());
//            			}
//            			if (!StringUtils.isEmpty(item.getSourceGumsa())) {
//            				info.setSourceGumsa(item.getSourceGumsa());
//            			}
//            			if (!StringUtils.isEmpty(item.getGroupGubun())) {
//            				info.setGroupGubun(item.getGroupGubun());
//            			}
//            			if (!StringUtils.isEmpty(item.getGroupHangmog())) {
//            				info.setGroupHangmog(item.getGroupHangmog());
//            			}
//            			if (!StringUtils.isEmpty(item.getDisplayYn())) {
//            				info.setDisplayYn(item.getDisplayYn());
//            			}
//            			if (!StringUtils.isEmpty(item.getKeyValue())) {
//            				info.setKeyValue(item.getKeyValue());
//            			}
//            			response.addGrdResultList(info);
//            		}
//            	}
//            	
//            	List<ComboListItemInfo> listFwkActorList = adm3200Repository.getFwkActorListItem(getHospitalCode(), request.getUserGroupFwkActor());
//            	if(listFwkActorList != null && !listFwkActorList.isEmpty()){
//            		for(ComboListItemInfo item : listFwkActorList){
//            			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
//            			if (!StringUtils.isEmpty(item.getCode())) {
//            				info.setCode(item.getCode());
//            			}
//            			if (!StringUtils.isEmpty(item.getCodeName())) {
//            				info.setCodeName(item.getCodeName());
//            			}
//            			response.addFwkActorList(info);
//            		}
//            	}
//            	
//            	String userNmVsvJubsuja = adm3200Repository.getCPL3020U00UserNmVsvJubsuja(getHospitalCode(), request.getCodeVsvJubsuja());
//            	if(userNmVsvJubsuja != null && !userNmVsvJubsuja.isEmpty()){
//            		response.setUserNmVsvJubsuja(userNmVsvJubsuja);
//            	}
//            	
//            	String codeNameVsvJundalGubun = cpl0109Repository.getCodeNameVsvJundalGubun(getHospitalCode(), request.getCodeTypeVsvJundalGubun(),request.getCodeVsvJundalGubun(), getLanguage());
//            	if(codeNameVsvJundalGubun != null && !codeNameVsvJundalGubun.isEmpty()){
//            		response.setCodeNameVsvJundalGubun(codeNameVsvJundalGubun);
//            	}
//            	
//            	String noteVsvNote = cpl0111Repository.getNoteVsvNote(getHospitalCode(), request.getJundalGubunVsvNote(),request.getCodeVsvJundalGubun());
//            	if(noteVsvNote != null && !noteVsvNote.isEmpty()){
//            		response.setNoteVsvNote(noteVsvNote);
//            	}
//            	
//	            LOGGER.info("RESPONSE: " + response.build().toString());
//	            rpcBuilder.setPayloadClass(CplsServiceProto.CPL3010U00ExecuteResponse.class.getSimpleName());
//	            rpcBuilder.setPayloadData(response.build().toByteString());
//            } catch (Exception e) {
//            	rpcBuilder.setResult(Rpc.RpcMessage.Result.INTERNAL_ERROR);
//            	LOGGER.error(e.getMessage(),e);
//			} finally {
//				message.reply(rpcBuilder.build().toByteArray());
//		        LOGGER.info("[END] CPL3010U00ExecuteHandler");
//			}
//        } catch (InvalidProtocolBufferException e) {
//        	LOGGER.error(e.getMessage(),e);
//        }
//	}
//}
