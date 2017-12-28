package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import org.junit.Test;
import nta.med.service.integration.MessageRequestTest;

public class BAS0250U00FbxHoGradeValidatingTest extends MessageRequestTest {

	@Test
	public void testBAS0250U00FbxHoGradeValidating() throws InterruptedException {
        BassServiceProto.BAS0250U00FbxHoGradeValidatingRequest request = BassServiceProto.BAS0250U00FbxHoGradeValidatingRequest.newBuilder()
        		.setHoGrade("00")
        		.setHoGradeYmd("2016/02/02")
                .build();
        sentRequestToMedApp(request, BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}